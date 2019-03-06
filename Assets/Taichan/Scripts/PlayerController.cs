using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody _rigidbody;
	[SerializeField] private int speed = 20;
	[SerializeField] private int jumpPower = 200;
	private bool canJump = true;
	private bool canMoveH = true;
	private int up = 0;
	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		float hInput = Input.GetAxis("Horizontal");
		up = 0;
		if (Input.GetKeyDown(KeyCode.Space) && canJump)
		{
			up = 1;
			canJump = false;
		}

		_rigidbody.AddForce(hInput * speed * Convert.ToInt32(canMoveH), jumpPower * up, 0);
	}

	private void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.CompareTag("Floor"))
		{
			canJump = true;
			canMoveH = true;
		}
//		else if(_rigidbody.velocity.y < 0.05f)
//		{
//			canMoveH = false;
//		}
	}
}