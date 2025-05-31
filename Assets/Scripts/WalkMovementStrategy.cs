using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class WalkMovementStrategy : IMovementStrategy
{
	public void Move(Rigidbody rb, Transform cameraPivot, InputAction move, MovementSetting movementSetting, ref Boolean isSprinting, InputAction sprint, Boolean isGrounded)
	{
		var moveVector = move.ReadValue<Vector2>();
		isSprinting = sprint.IsPressed() && isGrounded;
		if (moveVector.sqrMagnitude < 0.01f)
		{
			Vector3 stop = rb.linearVelocity;
			stop.x = 0;
			stop.z = 0;
			rb.linearVelocity = stop;
			return;
		}

		Vector3 forward = cameraPivot.forward;
		Vector3 right = cameraPivot.right;
		forward.y = 0;
		right.y = 0;
		forward.Normalize();
		right.Normalize();

		Vector3 direction = (forward * moveVector.y + right * moveVector.x).normalized;
		float speed = isSprinting ? movementSetting.sprintSpeed : movementSetting.speed;
		Vector3 velocity = direction * speed;
		velocity.y = rb.linearVelocity.y;

		rb.linearVelocity = velocity;
	}
}