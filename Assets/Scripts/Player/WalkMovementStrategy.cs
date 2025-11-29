using System;
using UnityEngine;

namespace Player
{
	public class WalkMovementStrategy : IMovementStrategy
	{
		public void Move(PlayerContext context)
		{
			if (context.InputCache.MoveInput == Vector2.zero)
			{
				context.State.IsMoving = false;
				return;
			}

			Vector3 forward = context.CameraPivot.forward;
			Vector3 right = context.CameraPivot.right;

			forward.y = 0f;
			right.y = 0f;

			forward.Normalize();
			right.Normalize();

			Vector3 moveDir = forward * context.InputCache.MoveInput.y + right * context.InputCache.MoveInput.x;
			Single speed = context.InputCache.SprintPressed ? context.Settings.sprintSpeed : context.Settings.speed;
			Vector3 targetPosition = context.Rigidbody.position + moveDir.normalized * speed * Time.fixedDeltaTime;

			context.Rigidbody.MovePosition(targetPosition);
			context.State.IsMoving = true;
		}
	}
}

