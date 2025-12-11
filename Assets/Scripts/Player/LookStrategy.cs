using Input;
using Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace Player
{
	public class LookStrategy : ILookStrategy
	{
		private readonly Transform _charControl;
		private readonly CharacterState _state;
		private readonly MovementSetting _setting;
		private readonly PlayerInputCache _inputCache;
		private readonly GameObject _head;

		public LookStrategy(
			Transform charControl,
			CharacterState state,
			MovementSetting setting,
			PlayerInputCache inputCache,
			GameObject head)
		{
			_charControl = charControl;
			_state = state;
			_setting = setting;
			_inputCache = inputCache;
			_head = head;
		}

		public void Look()
		{
			_state.VerticalLookAngle -= _inputCache.LookInput.y * _setting.lookSensitivity;
			_state.VerticalLookAngle = Mathf.Clamp(_state.VerticalLookAngle, _setting.minLookAngle, _setting.maxLookAngle);

			_head.transform.localRotation = Quaternion.Euler(_state.VerticalLookAngle, 0, 0);
			_charControl.Rotate(Vector3.up * _inputCache.LookInput.x * _setting.lookSensitivity);

			Debug.Log("Look");
		}
	}
}