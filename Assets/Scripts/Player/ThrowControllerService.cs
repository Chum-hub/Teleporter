using System;
using Data;
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
		private readonly CharacterLookData _lookData;
		private readonly PlayerInputCache _inputCache;
		private readonly Rigidbody _pLayerRb;
		private readonly TeleportProjectileFactory _teleportFactory;
		private readonly Vector3 _offset = new Vector3(0, 0, 1);
		private TeleportProjectileType _type;

		public ThrowControllerService
		(
			TeleportProjectileFactory teleportFactory,
			CharacterState playerState,
			PlayerInputCache inputCache,
			Rigidbody playerRb, CharacterLookData lookData)
		{
			Debug.Log("[ThrowControllerService] Constructor called");
			_teleportFactory = teleportFactory;
			_playerState = playerState;
			_inputCache = inputCache;
			_pLayerRb = playerRb;
			_lookData = lookData;

			Debug.Log($"[ThrowControllerService] Initialized - Factory: {_teleportFactory != null}, State: {_playerState != null}, Input: {_inputCache != null}, RB: {_pLayerRb != null}");
		}

		private void Throw(TeleportProjectileType type, Vector3 dir)
		{
			if (_inputCache.ThrowPressed)
			{
				var teleportProjectile = _teleportFactory.Create(type);
				teleportProjectile.gameObject.SetActive(true);
				var teleportRb = teleportProjectile.GetComponent<Rigidbody>();
				teleportProjectile.GetPosition();
				teleportRb.transform.Translate(_pLayerRb.transform.forward + _offset, Space.World);
				teleportRb.AddForce(dir, ForceMode.Impulse);
			}
		}

		public void FixedTick()
		{
			Throw(TeleportProjectileType.Fire, _lookData.GetLookDirection());
		}
	}
}