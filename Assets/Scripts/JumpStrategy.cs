using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpStrategy : IJumpStrategy
{
	public void Jump(ref Boolean  isGrounded, Rigidbody rb, MovementSetting movementSetting, InputAction jump)
	{
		if (!isGrounded || !jump.IsPressed()) return;
		rb.AddForce(Vector3.up * movementSetting.jumpForce, ForceMode.Impulse);
		isGrounded = false;
	} 
}
