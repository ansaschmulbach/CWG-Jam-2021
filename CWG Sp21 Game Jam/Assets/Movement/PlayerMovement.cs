using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region Inspector Variables

    [SerializeField] private float m_speed;
    [SerializeField] private float m_gravity;
    [SerializeField] private float m_jumpPow;
    [SerializeField] private float yScaleAmt;
    [SerializeField] private float m_jumpHeight;
    [SerializeField] private float m_yDir;
    
    #endregion

    #region Cached Variables

    private Rigidbody2D cr_rb;

    #endregion

    #region Public Vars

    [Header("Don't Edit")]
    public bool touchingGround;
    public float originalY;
    public bool isJumping;

    #endregion

    #region Private Vars

    private float yDelta;
    private float preDeltaY;
    private int debugCount;

    #endregion
    
    void Start()
    {
        cr_rb = GetComponent<Rigidbody2D>();
        touchingGround = true;
        isJumping = false;
        // m_speed = 150f;
        // m_gravity = 12;
        // m_jumpSpeed = 300;
        // yScaleAmt = 0.015f;
    }

    // Update is called once per frame
    void Update()
    {
        float xMov = Input.GetAxis("Horizontal");
        float yMov = Input.GetAxis("Vertical");
        bool space = Input.GetKeyDown("space");

        Vector3 vel = Vector3.right * (xMov * m_speed);

        if (!space && !isJumping)
        {
            vel += Vector3.up * (yMov * m_speed);
            if (!touchingGround) {
                //Destroy(this.gameObject);
            }
        } 
        else if (!isJumping && space)
        {
            vel += Vector3.up * m_jumpPow;
            isJumping = true;
            yDelta = 0;
            originalY = this.transform.position.y;
            cr_rb.velocity = vel;
            debugCount = 0;
            preDeltaY = vel.y;
            this.transform.position += Vector3.up * 0.00001f;
            Debug.Log(cr_rb.velocity.y);
            return;
        }
        
        if (isJumping)
        {
            debugCount++;
            preDeltaY -= (m_gravity * Time.deltaTime);
            vel.y = preDeltaY;
            yDelta += CalcYDelta(yMov) * Time.deltaTime;
            vel += Vector3.up * CalcYDelta(yMov);

            cr_rb.velocity = vel;
            
            float currYDelta = this.transform.position.y - originalY;
            //Debug.Log(yDelta + " " + currYDelta);
            Debug.Log(CalcYDelta(yMov) + " " + vel.y + " " + preDeltaY);
            Debug.Log(currYDelta + " " + yDelta);
            if (currYDelta <= yDelta && preDeltaY < 0)
            {
                //Debug.Log(currYDelta + " " + yDelta );
                vel = Vector3.zero;
                isJumping = false;
            }
        }

        cr_rb.velocity = vel;

    }

    float CalcYDelta(float yMov)
    {
        return yMov * m_speed * yScaleAmt;
    }
    
    
}
