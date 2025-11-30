using System;
using Input;
using UnityEngine;
using Zenject;

namespace Player
{
	public class ThrowControllerService : IFixedTickable
	{

		private readonly Timer.Timer _timer = new Timer.Timer();
		private CharacterState _playerState;
		private PlayerInputCache _inputCache;

		public ThrowControllerService(PlayerContext context)
		{
			
		}

		private Rigidbody _rb;

		public void FixedTick()
		{
			// if (_inputCache.ThrowPressed) ToThrow();
		}

		// private void ToThrow()
		// {
		// 	_inputCache.ThrowPressed = false;
		//
		// 	var verticalAngle = _playerState.VerticalLookAngle + 10f;
		// 	GameObject projectile = Instantiate(_projectilePrefab, _throwOrigin.position, Quaternion.identity);
		//
		// 	Vector3 direction = _throwOrigin.forward;
		// 	direction.y = 0f;
		// 	direction.Normalize();
		//
		// 	Quaternion pitchRotation = Quaternion.AngleAxis(verticalAngle, _throwOrigin.right);
		// 	direction = pitchRotation * direction;
		//
		// 	Rigidbody rb = projectile.GetComponent<Rigidbody>();
		// 	rb.AddForce(direction * _throwForce, ForceMode.Impulse);
		// }
	}
}