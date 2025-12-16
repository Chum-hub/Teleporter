using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;
using Zenject;

namespace Teleport
{
	public class TeleportProjectileFire : TeleportProjectileBase
	{
		[Inject]
		public void Construct(
			List<Buffs> buffs,
			ScriptableObjects.Teleport teleportFire
		)
		{
			_buffsList = buffs;
			_teleportSetting = teleportFire;
		}

		public override void OnCollisionEnter(Collision other)
		{
			throw new NotImplementedException();
		}

		public override void Detonate()
		{
			throw new NotImplementedException();
		}
	}
}