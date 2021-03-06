﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	protected Rigidbody2D rb;
	public float MovingSpeed = 2;
    public float m_MovementspeedMultiplyer = 1;

    public float m_JumpHeightMultiplier = 1f;
    public float MaxJumpHeight = 1f;
    public float InitJumpSpeed = 10f;
    private Vector2 m_MaxJumpPosition = new Vector2();
    private bool mIsJumping = false;

    private Animator m_Animator;

    private bool isGrounded;

    public float JumpHeight
    {
        get { return MaxJumpHeight * m_JumpHeightMultiplier; }
    }

    public float MovementSpeed
    {
        get { return MovingSpeed * m_MovementspeedMultiplyer; }
    }

    private void Awake()
    {
        Physics2D.gravity = new Vector2(0f, -20f);
        m_Animator = GetComponent<Animator>();

        GameManager.Instance.HideBSOD();
        CameraController.Instance.Restart();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		Vector2 direction = new Vector2();
        //isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatCanStandOn);

        direction.x = Input.GetAxis("Horizontal");

        if(direction != Vector2.zero)
            Move(direction);
        else if(isGrounded)
            m_Animator.Play("IDLE");

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
            //rb.AddForce(new Vector2(rb.velocity.x, JumpForce));
            //mIsJumping = true;
            //mMaxJumpPosition = new Vector2(0, rb.position.y + JumpHeight);
            JumpTrigger();

        }

        if(mIsJumping)
        {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Standable")
            isGrounded = true;

        if (mIsJumping && LayerMask.LayerToName(collision.gameObject.layer) == "Standable")
            mIsJumping = !mIsJumping;

        if (LayerMask.LayerToName(collision.gameObject.layer) == "Boundable")
        {
            JumpTrigger();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Standable")
            isGrounded = false;
    }

    void Move(Vector2 aDir)
	{
		rb.velocity = aDir * MovementSpeed;

        if(aDir == Vector2.right)
            GetComponent<SpriteRenderer>().flipX = false;
        else if(aDir == Vector2.left)
            GetComponent<SpriteRenderer>().flipX = true;

        if(isGrounded)
            m_Animator.Play("Run_Player");
    }

    void JumpTrigger()
    {
        mIsJumping = true;
        m_MaxJumpPosition = new Vector2(0, rb.position.y + JumpHeight);
        m_Animator.Play("Jump_Player");
    }

    void Jump()
    {
        rb.position += new Vector2(0, InitJumpSpeed * UnityEngine.Time.deltaTime);
        if (rb.position.y >= m_MaxJumpPosition.y)
        {
            mIsJumping = !mIsJumping;
            m_Animator.Play("Falling_Player");
        }
    }

    private void Death()
    {
        if(GameManager.Instance != null)
            GameManager.Instance.ShowBSOD();

        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Death();
    }
}
