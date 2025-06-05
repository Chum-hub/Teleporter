using UnityEngine;

public class JumpStrategy : IJumpStrategy
{
	public void Jump(Rigidbody rb, MovementSetting settings, bool jumpPressed, CharacterState state)
	{
		if (!jumpPressed || !state.IsGrounded) return;

		rb.AddForce(Vector3.up * settings.jumpForce, ForceMode.Impulse);
		state.IsGrounded = false;
	}
}