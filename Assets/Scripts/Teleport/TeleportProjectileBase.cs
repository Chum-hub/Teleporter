using System;
using System.Collections.Generic;
using Enums;
using Interfaces;
using UnityEngine;

namespace Teleport
{
	public abstract class TeleportProjectileBase : MonoBehaviour, ITeleportThrowable
	{
		[SerializeField] protected ScriptableObjects.Teleport _teleportSetting;
		protected List<Buffs> _buffsList;
		
		
		protected abstract void OnCollisionEnter(Collision other);

		protected void SetBuffs(Buffs buff)
		{
			_buffsList.Add(buff);
		}

		protected List<Buffs> GetBuff()
		{
			return _buffsList;
		}

		public Transform GetPosition()
		{
			return gameObject.transform;
		}

		protected void SetPosition(Vector3 pos)
		{
			gameObject.transform.Translate(pos);
		}

		protected Single GetSpeed()
		{
			return _teleportSetting._speed;
		}

		protected abstract void Detonate();

		protected void Destroy()
		{
			Destroy(gameObject);
		}
	}
}