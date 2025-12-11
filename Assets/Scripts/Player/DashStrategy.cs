using System;
using Input;
using ScriptableObjects;
using UnityEngine;

namespace Player
{
	public class DashStrategy : IDashStrategy
	{
		private Single _lastDashTime;

		private readonly Timer.Timer _timer;

		private readonly CharacterState _state;

		private readonly MovementSetting _setting;

		private readonly PlayerInputCache _inputCache;

		private readonly GameObject _head;

		private readonly Rigidbody _rb;

		public DashStrategy(
			Timer.Timer timer,
			CharacterState state,
			MovementSetting setting,
			PlayerInputCache inputCache,
			GameObject head,
			Rigidbody rb)
		{
			_timer = timer;
			_state = state;
			_setting = setting;
			_inputCache = inputCache;
			_head = head;
			_rb = rb;
		}

		public void Dash()
		{
			Debug.Log($"{_inputCache.DashPressed}");

			if (!_inputCache.DashPressed)
				return;
			
			if (!_timer.IsCooldownDone(_lastDashTime, _setting.dashCooldown))
				return;
			
			_state.IsDashReady = true;

			var camTransform = _head.transform;
			var forwardDir = camTransform.forward;
			var rightDir = camTransform.right;

			forwardDir.y = 0f;
			rightDir.y = 0f;

			var dashDir = (forwardDir * _inputCache.MoveInput.y + rightDir * _inputCache.MoveInput.x).normalized;
			if (dashDir == Vector3.zero)
				dashDir = forwardDir;

			_rb.AddForce(dashDir.normalized * _setting.dashForce, ForceMode.Impulse);
			
			_state.IsDashReady = false;
			_lastDashTime = Time.time;
		}
	}
}