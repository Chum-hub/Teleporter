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
			List<Buffs> buffs
		)
		{
			_buffsList = buffs;
		}

		protected override void OnCollisionEnter(Collision other)
		{
			throw new NotImplementedException();
		}

		protected override void Detonate()
		{
			throw new NotImplementedException();
		}
	}
}