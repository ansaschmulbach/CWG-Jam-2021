using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region Inspector Variables

    [SerializeField] private float m_speed;
    [SerializeField] private float m_gravity;
    [SerializeField] private float m_jumpSpeed;
    [SerializeField] private float yScaleAmt;
    //[SerializeField] private float m_jumpHeight;
    
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

    #endregion
    
    void Start()
    {
        cr_rb = GetComponent<Rigidbody2D>();
        touchingGround = true;
        isJumping = false;
        m_speed = 150f;
        m_gravity = 12;
        m_jumpSpeed = 300;
        yScaleAmt = 0.015f;
    }

    // Update is called once per frame
    void Update()
    {
        float xMov = Input.GetAxis("Horizontal");
        float yMov = Input.GetAxis("Vertical");
        bool space = Input.GetKeyDown("space");

        Vector3 vel = Vector3.right * (xMov * m_speed * Time.deltaTime);

        if (!space && !isJumping)
        {
            vel += Vector3.up * (yMov * m_speed * Time.deltaTime);
            if (!touchingGround) {
                Destroy(this.gameObject);
            }
        } 
        else if (!isJumping && space)
        {
            vel += Vector3.up * (m_jumpSpeed * Time.deltaTime);
            isJumping = true;
            yDelta = 0;
            originalY = this.transform.position.y;
            cr_rb.velocity = vel;
            return;
        }
        
        if (isJumping)
        {
            vel.y = cr_rb.velocity.y;
            vel += Vector3.down * (m_gravity * Time.deltaTime);
            yDelta += CalcYDelta(yMov);
            if (yDelta < 0)
            {
                vel += Vector3.up * (-0.005f);   
            }
            cr_rb.velocity = vel;
            float currYDelta = this.transform.position.y - originalY;
            Debug.Log(yDelta + " " + currYDelta);
            if (yDelta > 0 && currYDelta < yDelta || 
                yDelta < 0 && currYDelta < yDelta || 
                yDelta == 0 && currYDelta <= 0)
            {
                vel = Vector3.zero;
                isJumping = false;
            }
        }

        cr_rb.velocity = vel;

    }

    float CalcYDelta(float yMov)
    {
        if (yMov > 0)
        {
            return yMov * m_speed * Time.deltaTime * yScaleAmt * 1.5f;
        }
        else
        {
            return yMov * m_speed * Time.deltaTime * yScaleAmt;
        }
    }
    
    
}
