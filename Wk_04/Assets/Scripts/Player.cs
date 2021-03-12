using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public PlayerStates state;
	public Rigidbody RB;

	public bool isGrounded;
	public Transform groundCheck;
	public LayerMask groundMask;

    void Start()
    {
        RB = this.GetComponent<Rigidbody>();
    }

  
    void Update()
    {
		CheckForGround();

		if(state == PlayerStates.Grounded)
		{
			if(isGrounded == false)
			{
				state = PlayerStates.Airborne;
				return;
			}

			if(Input.GetKey(KeyCode.S))
			{
				state = PlayerStates.Crouching;
				return;
			}

			MoveOnGround();
			// Jump
			if(Input.GetKeyDown(KeyCode.Space))
				RB.AddForce(Vector3.up * 5, ForceMode.Impulse);
		}

		else if(state == PlayerStates.Airborne)
		{
			if(isGrounded == true)
			{
				state = PlayerStates.Grounded;
				return;
			}
			MoveInAir();
		}
		else if(state == PlayerStates.Crouching)
		{
			if(!Input.GetKey(KeyCode.S))
			{
				state = PlayerStates.Grounded;
				this.transform.localScale = Vector3.one;
				return;
			}
			if(isGrounded == false)
			{
				state = PlayerStates.Airborne;
				this.transform.localScale = Vector3.one;
				return;
			}
			this.transform.localScale = new Vector3(1,0.5f,1);

			// Jump
			if (Input.GetKeyDown(KeyCode.Space))
				RB.AddForce(Vector3.up * 20, ForceMode.Impulse);
		}

	}

	void CheckForGround()
	{
		Ray groundRay = new Ray(groundCheck.position, Vector3.down);
		RaycastHit groundHit;

		isGrounded = Physics.Raycast(groundRay, out groundHit, 0.25f, groundMask);
	}

	void MoveOnGround()
	{
		float dir = Input.GetAxis("Horizontal");
		RB.AddForce(Vector3.right * dir * 50, ForceMode.Acceleration);
		RB.velocity = Vector3.ClampMagnitude(RB.velocity, 10);
	}

	void MoveInAir()
	{
		float dir = Input.GetAxis("Horizontal");
		RB.AddForce(Vector3.right * dir * 10, ForceMode.Acceleration);
		RB.velocity = Vector3.ClampMagnitude(RB.velocity, 10);
	}


}

public enum PlayerStates
{
	Grounded,
	Airborne,
	Crouching
}
