using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    #region Inspector Variables

    [SerializeField] private float m_speed;
    [SerializeField] private float m_gravity;
    [SerializeField] private float m_jumpPow;
    [SerializeField] private float yScaleAmt;

    #endregion

    #region Cached Variables

    private Rigidbody2D cr_rb;
    private Animator animator;
    private Vector3 scale;
    
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

    #endregion

    #region Instantiation Method

    void Start()
    {
        cr_rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingGround = true;
        isJumping = false;
        scale = transform.localScale;
    }

    #endregion
    
    void Update()
    {
        float xMov = Input.GetAxis("Horizontal");
        float yMov = Input.GetAxis("Vertical");
        bool space = Input.GetKeyDown("space");

        Vector3 vel = Vector3.right * (xMov * m_speed);

        if (space && !isJumping)
        {
            StartJump(vel);
        } 
        else if (!isJumping)
        {
            vel += Vector3.up * (yMov * m_speed);
            if (!touchingGround) {
                //Destroy(this.gameObject);
            }
            this.cr_rb.velocity = vel;
        } 
        else
        {
            JumpContinue(vel, yMov);
        }
        
        UpdateAnimator(xMov, yMov);

    }

    #region Jump Methods

    void StartJump(Vector3 vel)
    {
        vel += Vector3.up * m_jumpPow;
        isJumping = true;
        yDelta = 0;
        originalY = this.transform.position.y;
        cr_rb.velocity = vel;
        preDeltaY = vel.y;
        this.transform.position += Vector3.up * 0.00001f;
    }

    void JumpContinue(Vector3 vel, float yMov)
    {
        preDeltaY -= (m_gravity * Time.deltaTime);
        vel.y = preDeltaY;
        yDelta += CalcYDelta(yMov) * Time.deltaTime;
        vel += Vector3.up * CalcYDelta(yMov);
        cr_rb.velocity = vel;
        float currYDelta = this.transform.position.y - originalY;
        if (currYDelta <= yDelta && preDeltaY < 0)
        {
            vel = Vector3.zero;
            isJumping = false;
        }
        cr_rb.velocity = vel;
    }
    
    
    float CalcYDelta(float yMov)
    {
        return yMov * m_speed * yScaleAmt;
    }

    #endregion

    #region Animator

    int AnimatorState(float xMov, float yMov) 
    {
        Debug.Log(yMov - Math.Abs(xMov * 2));
        if (isJumping)
        {
            return 0;
        }
        if (Math.Abs(xMov) - Math.Abs(yMov) > 0.2)
        {
            if (xMov > 0)
            {
                this.transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
            }
            else
            {
                this.transform.localScale = scale;
            }
            return 2;
        }
        if (yMov > 0)
        {
            return 3;
        }

        return 1;
    }

    void UpdateAnimator(float xMov, float yMov)
    {
        int anim = AnimatorState(xMov, yMov);
        switch (anim)
        {
            case 0:
                animator.SetBool("jump", true);
                animator.SetBool("front", false);
                animator.SetBool("side walk", false);
                animator.SetBool("back", false);
                break;
            case 1:
                animator.SetBool("jump", false);
                animator.SetBool("front", true);
                animator.SetBool("side walk", false);
                animator.SetBool("back", false);
                break;
            case 2:
                animator.SetBool("jump", false);
                animator.SetBool("front", false);
                animator.SetBool("side walk", true);
                animator.SetBool("back", false);
                break;
            case 3:
                animator.SetBool("jump", false);
                animator.SetBool("front", false);
                animator.SetBool("side walk", false);
                animator.SetBool("back", true);
                break;
        }
    }

    #endregion
    

}
