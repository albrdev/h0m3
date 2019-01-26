using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	protected Rigidbody2D rb;
	public float MovingSpeed = 3;
    public float mMovementspeedMultiplyer = 1;

    public float JumpForce = 100f;
    public float mJumpforceMultiplyer = 1f;
    public float MaxJumpHeight = 100f;
    public float InitJumpSpeed = 10f;
    private Vector2 mMaxJumpPosition = new Vector2();
    private float mCurrentJumpHeight = 0;
    private bool mIsJumping = false;

    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatCanStandOn;
    bool IsJumping = false;
    float JumpTimer;
    float JumpTime = 2f;


    public float MovementSpeed
    {
        get { return MovingSpeed * mMovementspeedMultiplyer; }
    }

    private void Awake()
    {
        Physics2D.gravity = new Vector2(0f, -20f);
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

        Move(direction);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
            //rb.AddForce(new Vector2(rb.velocity.x, JumpForce));
            mIsJumping = true;
            mMaxJumpPosition = new Vector2(0, rb.position.y + MaxJumpHeight);

        }

        if(mIsJumping)
        {
            rb.position += new Vector2(0, InitJumpSpeed * UnityEngine.Time.deltaTime);
            Debug.Log(mCurrentJumpHeight);
            if (rb.position.y >= mMaxJumpPosition.y)
            {
                mIsJumping = !mIsJumping;
                //mCurrentJumpHeight = 0;
            }
            //rb.velocity += Vector2.up * mCurrentJumpHeight;
        }

        //if(rb.velocity.y < 0f)
        //    rb.velocity += Vector2.up * Physics2D.gravity.y * (2.5f * UnityEngine.Time.deltaTime);
        //if(rb.velocity.y > 0f && !Input.GetKey(KeyCode.Space))
        //    rb.velocity += Vector2.up * Physics2D.gravity.y * (2f * UnityEngine.Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit ground");
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Standable")
            isGrounded = true;

        if (mIsJumping && LayerMask.LayerToName(collision.gameObject.layer) == "Standable")
            mIsJumping = !mIsJumping;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Left ground");
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Standable")
            isGrounded = false;
    }

    void Move(Vector2 aDir)
	{
		rb.velocity = aDir * MovementSpeed;
	}
}
