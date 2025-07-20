using Player;
using UnityEngine;

public class JumpStrategy : IJumpStrategy
{
	public void Jump(PlayerContext context)
	{
		if (!context.InputCache.JumpPressed || !context.State.IsGrounded) return;

		context.Rigidbody.AddForce(Vector3.up * context.Settings.jumpForce, ForceMode.Impulse);
		context.State.IsGrounded = false;
	}
}