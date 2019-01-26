using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	protected Rigidbody2D rgdb;
	public float MovingSpeed = 3;
    public float JumpForce = 3;
	
    // Start is called before the first frame update
    void Start()
    {
        rgdb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		Vector2 direction = new Vector2();
		
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
				direction.x = -1;
		}

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
				direction.x = 1;
		}
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("Space key was pressed.");
            rgdb.AddForce(new Vector2(rgdb.velocity.x, JumpForce));
		}

		Move(direction);
    }
	
	void Move(Vector2 aDir)
	{
		rgdb.velocity = aDir * MovingSpeed;
	}
}
