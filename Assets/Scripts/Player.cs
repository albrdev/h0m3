using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	protected Rigidbody2D rb;
	public float MovingSpeed = 3;
    public float mMovementspeedMultiplyer = 1;

    public float JumpForce = 100;
    public float mJumpforceMultiplyer = 1;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatCanStandOn;


    public float MovementSpeed
    {
        get { return MovingSpeed * mMovementspeedMultiplyer; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		Vector2 direction = new Vector2();
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatCanStandOn);

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
				direction.x = -1;
		}

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
				direction.x = 1;
		}

        Move(direction);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
            rb.velocity = Vector2.up * JumpForce * mJumpforceMultiplyer;
		}


    }

	void Move(Vector2 aDir)
	{
		rb.velocity = aDir * MovementSpeed;
	}
}
