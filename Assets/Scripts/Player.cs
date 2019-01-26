using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	protected Rigidbody2D rgdb;
	
    // Start is called before the first frame update
    void Start()
    {
        rgdb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		Vector2 direction = new Vector2();
		
        if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
				direction.x = -1;
		}

        if(Input.GetKeyDown(KeyCode.RightArrow))
		{
				direction.x = 1;
		}

		Move(direction);
    }
	
	void Move(Vector2 aDir)
	{
		rgdb.position = rgdb.position + aDir;
	}
}
