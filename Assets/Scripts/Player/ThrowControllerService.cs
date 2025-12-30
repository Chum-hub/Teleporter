using System;
using System.Collections.Generic;
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

		private readonly CharacterLookData _lookData;
		private readonly PlayerInputCache _inputCache;
		private readonly Character _character;
		private readonly TeleportProjectileFactory _teleportFactory;
		private readonly Vector3 _offset = new Vector3(0, 0, 1);
		private TeleportProjectileType _type;
		private List<ScriptableObject> _prefabSettings;

		public ThrowControllerService
		(
			TeleportProjectileFactory teleportFactory,
			PlayerInputCache inputCache,
			Character character,
			CharacterLookData lookData
		)
		{
			_teleportFactory = teleportFactory;
			_inputCache = inputCache;
			_character = character;
			_lookData = lookData;
		}

		private void Throw(TeleportProjectileType type, Vector3 dir)
		{
			if (_inputCache.ThrowPressed)
			{
				var teleportProjectile = _teleportFactory.Create(type);
				//teleportProjectile.gameObject.SetActive(true);
				var teleportRb = teleportProjectile.GetComponent<Rigidbody>();
				
				teleportProjectile.gameObject.transform.Translate(_character.gameObject.transform.position + _offset, Space.World);
				teleportRb.AddForce(dir, ForceMode.Impulse);
			}
		}

		public void FixedTick()
		{
			Throw(TeleportProjectileType.Fire, _lookData.GetLookDirection());
		}
	}
}