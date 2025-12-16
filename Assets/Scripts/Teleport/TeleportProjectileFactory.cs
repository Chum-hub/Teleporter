using System.Collections.Generic;
using Enums;
using Zenject;

namespace Teleport
{
	public class TeleportProjectileFactory
	{
		private readonly DiContainer _container;
		private readonly Dictionary<TeleportProjectileType, TeleportProjectileBase> _prefabs;

		public TeleportProjectileFactory(
			DiContainer container,
			Dictionary<TeleportProjectileType, TeleportProjectileBase> prefabs)
		{
			_container = container;
			_prefabs = prefabs;
		}

		public TeleportProjectileBase Create(TeleportProjectileType type)
		{
			var teleportProjectile = _prefabs[type];
			return _container.InstantiatePrefabForComponent<TeleportProjectileBase>(teleportProjectile);
		}
	}
}