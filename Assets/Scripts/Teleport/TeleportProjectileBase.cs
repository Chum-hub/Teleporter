using System;
using System.Collections.Generic;
using Enums;
using Interfaces;
using UnityEngine;

namespace Teleport
{
	public abstract class TeleportProjectileBase : MonoBehaviour, ITeleportThrowable
	{
		protected ScriptableObjects.Teleport _teleportSetting;
		protected List<Buffs> _buffsList;
		
		
		public abstract void OnCollisionEnter(Collision other);

		public void SetBuffs(Buffs buff)
		{
			_buffsList.Add(buff);
		}

		public List<Buffs> GetBuff()
		{
			return _buffsList;
		}

		public Transform GetPosition()
		{
			return gameObject.transform;
		}

		public Single GetSpeed()
		{
			return _teleportSetting._speed;
		}

		public abstract void Detonate();

		public void Destroy()
		{
			Destroy(gameObject);
		}
	}
}