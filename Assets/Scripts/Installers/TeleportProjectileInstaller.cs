using System.Collections.Generic;
using Enums;
using Player;
using Teleport;
using UnityEngine;
using Zenject;

namespace Installers
{
	public class TeleportProjectileInstaller : MonoInstaller
	{
		[SerializeField] private TeleportProjectileBase _firePrefab;

		public override void InstallBindings()
		{
			Container
				.Bind<TeleportProjectileFactory>()
				.AsSingle();

			Container
				.BindInstance
				(
					new Dictionary<TeleportProjectileType, TeleportProjectileBase>
					{
						{ TeleportProjectileType.Fire , _firePrefab}
					}
				);

			Container
				.BindInterfacesAndSelfTo<ThrowControllerService>()
				.AsSingle();
		}
	}
}