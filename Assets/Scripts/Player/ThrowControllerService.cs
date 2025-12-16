using System;
using Enums;
using Input;
using Teleport;
using UnityEngine;
using Zenject;

namespace Player
{
	public class ThrowControllerService : IFixedTickable
	{
		private readonly Timer.CooldownTimer _cooldownTimer;
		private readonly CharacterState _playerState;
		private readonly PlayerInputCache _inputCache;
		private readonly Rigidbody _rb;
		private readonly TeleportProjectileFactory _teleportFactory;
		public ThrowControllerService(TeleportProjectileFactory teleportFactory)
		{
			_teleportFactory = teleportFactory;
		}



		private void Throw(TeleportProjectileType type, Vector3 dir, Vector3 pos)
		{
			var teleportProjectile = _teleportFactory.Create(type);
			
		}

		public void FixedTick()
		{

		}
	}
}