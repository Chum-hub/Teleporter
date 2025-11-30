using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace ScriptableObjects
{
	[CreateAssetMenu(fileName = "TeleportProjectile", menuName = "Teleport")]
	public class FireTeleport : ScriptableObject
	{
		[Header("Type of Teleport")]
		public String name;

		[Space]
		
		[Header("Prefab")]
		public GameObject prefab;
		
		[Space]
		
		[Header("Attributes")]
		public Single throwForce;
		public Single speed;
		public Single damage;
	}
}