

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//
public class PlayerMovement : MonoBehaviour
{
	public CharacterController2D controller;
	public Rigidbody2D myRigidbody;
	public SpriteRenderer spriteRenderer;
	public Sprite characterBackwards;
	public Sprite characterForwards;
	public float horizontalMove = 0;
	public float runSpeed = 40;
	public bool jump = false;
	public float verticalMove = 0;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		verticalMove = Input.GetAxisRaw("Vertical");
		if (verticalMove == 1)
        {
			jump = true;
        }
        
	}

    void FixedUpdate()
    {
		// Move the character
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
		jump = false;
    }


}
