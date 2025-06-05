using UnityEngine;

public class WalkMovementStrategy : IMovementStrategy
{
	public void Move(Rigidbody rb, Transform cameraPivot, Vector2 moveInput, MovementSetting settings, bool isSprinting, CharacterState state)
	{
		if (moveInput == Vector2.zero)
		{
			state.IsMoving = false;
			return;
		}

		Vector3 forward = cameraPivot.forward;
		Vector3 right = cameraPivot.right;

		forward.y = 0f;
		right.y = 0f;

		forward.Normalize();
		right.Normalize();

		Vector3 moveDir = forward * moveInput.y + right * moveInput.x;
		float speed = isSprinting ? settings.sprintSpeed : settings.speed;
		Vector3 targetPosition = rb.position + moveDir.normalized * speed * Time.fixedDeltaTime;

		rb.MovePosition(targetPosition);
		state.IsMoving = true;
	}
}

