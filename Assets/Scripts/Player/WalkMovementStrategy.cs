using System;
using Input;
using ScriptableObjects;
using UnityEngine;

namespace Player
{
	public class WalkMovementStrategy : IMovementStrategy
	{
		private readonly CharacterState _state;

		private readonly MovementSetting _setting;

		private readonly PlayerInputCache _inputCache;

		private readonly GameObject _head;

		private readonly Rigidbody _rb;

		public WalkMovementStrategy(
			CharacterState state,
			MovementSetting setting,
			PlayerInputCache inputCache,
			GameObject head,
			Rigidbody rb)
		{
			_state = state;
			_setting = setting;
			_inputCache = inputCache;
			_head = head;
			_rb = rb;
		}

		public void Move()
		{
			if (_inputCache.MoveInput == Vector2.zero)
			{
				_state.IsMoving = false;
				return;
			}

			var transform = _head.transform;
			var forward = transform.forward;
			var right = transform.right;

			forward.y = 0f;
			right.y = 0f;

			forward.Normalize();
			right.Normalize();

			Vector3 moveDir = forward * _inputCache.MoveInput.y + right * _inputCache.MoveInput.x;
			Single speed = _inputCache.SprintPressed ? _setting.sprintSpeed : _setting.speed;
			Vector3 targetPosition = _rb.position + moveDir.normalized * speed * Time.fixedDeltaTime;

			_rb.MovePosition(targetPosition);
			_state.IsMoving = true;

			Debug.Log("move");
			Debug.Log($"{_setting.speed}");
		}
	}
}