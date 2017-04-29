using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxHeight;
	public float gScale;

	private float gScale0;
	private Rigidbody2D rigidbody;
	private Animator animator;
    private bool isAlive = true;

    private float JumpVelocity
	{
		get { return Mathf.Sqrt(2 * Mathf.Abs(Physics2D.gravity.y) * maxHeight); }
	}

	private bool IsJumping
	{
		get { return transform.position.y > -0.55; }
	}

	void Start ()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		gScale0 = rigidbody.gravityScale;
	}

	void Jump()
	{
		rigidbody.gravityScale = gScale;
		rigidbody.velocity = Vector2.up * JumpVelocity;
	}

	public void Die()
	{
		animator.SetTrigger("Die");
		isAlive = false;
		rigidbody.isKinematic = true;
		rigidbody.velocity = Vector2.zero;
	}

	void Update ()
	{
		if (isAlive)
		{
			if (GameInput.Jump && !IsJumping)
			{
				Jump();
			}
			else if(!GameInput.Jump && IsJumping)
			{
				rigidbody.gravityScale = gScale0;
			}
			animator.SetBool("Jumping", IsJumping);
		}
	}
}
