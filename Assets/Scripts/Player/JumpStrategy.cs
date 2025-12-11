using Input;
using ScriptableObjects;
using UnityEngine;

namespace Player
{
	public class JumpStrategy : IJumpStrategy
	{
		private readonly CharacterState _state;

		private readonly MovementSetting _setting;

		private readonly PlayerInputCache _inputCache;



		private readonly Rigidbody _rb;

		public JumpStrategy(
			CharacterState state,
			MovementSetting setting,
			PlayerInputCache inputCache,
			Rigidbody rb)
		{
			_state = state;
			_setting = setting;
			_inputCache = inputCache;
			_rb = rb;
		}

		public void Jump()
		{
			if (!_inputCache.JumpPressed || !_state.IsGrounded) return;

			_rb.AddForce(Vector3.up * _setting.jumpForce, ForceMode.Impulse);
			_state.IsGrounded = false;
		}
	}
}