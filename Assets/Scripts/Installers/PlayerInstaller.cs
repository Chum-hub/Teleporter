using System;
using Input;
using Interfaces;
using Player;
using UnityEngine;
using Zenject;

namespace Installers
{
	public class PlayerInstaller : MonoInstaller
	{
		[SerializeField] private Setting _setting;

		public override void InstallBindings()
		{
			Debug.Log("[PlayerInstaller] Installing player-specific bindings...");

			// Core dependencies
			Container.BindInterfacesAndSelfTo<PlayerInputCache>().AsSingle();
			Container.Bind<CharacterState>().AsSingle();
	

			// Prefab instantiation
			var playerInstance = Container.InstantiatePrefabForComponent<Player.Player>(
				_setting.playerPrefab,
				_setting.spawnPoint.position,
				Quaternion.identity,
				null
			);

			var playerInstanceTransform = playerInstance.transform;
			var playerRigidbody = playerInstance.GetComponent<Rigidbody>();
			var cameraPivot = playerInstanceTransform.Find("CameraPivot");
			if (cameraPivot is null)
			{
				Debug.LogError("[PlayerInstaller] CameraPivot not found in player prefab!");
				return;
			}

			Container.Bind<Transform>().WithId("PlayerTransform").FromInstance(playerInstanceTransform).AsTransient();
			Container.Bind<Rigidbody>().FromInstance(playerRigidbody).AsTransient();
			Container.Bind<Transform>().WithId("CameraPivot").FromInstance(cameraPivot).AsTransient();

			// Movement logic
			Container.Bind<IMovementStrategy>().To<WalkMovementStrategy>().AsTransient();
			Container.Bind<ILookStrategy>().To<LookStrategy>().AsTransient();
			Container.Bind<IJumpStrategy>().To<JumpStrategy>().AsTransient();
			Container.Bind<IDashStrategy>().To<DashStrategy>().AsTransient();

			// PlayerContext
			Container.Bind<PlayerContext>().FromMethod(ctx =>
			{
				var characterState = ctx.Container.Resolve<CharacterState>();
				var inputCache = ctx.Container.Resolve<PlayerInputCache>();
				var movementSetting = ctx.Container.Resolve<MovementSetting>();
				return new PlayerContext(playerInstanceTransform, characterState, movementSetting, playerRigidbody, inputCache, cameraPivot);
			}).AsSingle();


			// Controller service
			Container.BindInterfacesAndSelfTo<PlayerControllerService>().AsSingle();

			Debug.Log("[PlayerInstaller] Bindings complete.");
		}
	}

	[Serializable]
	public class Setting
	{
		public GameObject playerPrefab;
		public Transform spawnPoint;
	}
}
