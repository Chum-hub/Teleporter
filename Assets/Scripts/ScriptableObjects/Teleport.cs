using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace ScriptableObjects
{
	[CreateAssetMenu(fileName = "TeleportProjectile", menuName = "Teleport")]
	public class Teleport : ScriptableObject
	{
		[Header("Type of Teleport")]
		public String _name;

		[Space]
		[Header("Prefab")]
		public GameObject _prefab;
		public Rigidbody _rb;
		
		[Space]
		[Header("Attributes")]
		public Single _throwForce;
		public Single _speed;
		public Single _damage;

		[Space]

		[Header("Buffs")]
		public List<Buffs> _buffs;
	}
}