using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
	[SerializeField] private GameObject _playerPrefab;
	[SerializeField] private Transform _spawnPoint;

	public override void InstallBindings()
	{
		Debug.Log("[PlayerInstaller] Installing player-specific bindings...");

		// 1. Сначала биндим зависимости
		Container.Bind<IMovementStrategy>().To<WalkMovementStrategy>().AsSingle();
		Container.Bind<ILookStrategy>().To<LookStrategy>().AsSingle();
		Container.Bind<IJumpStrategy>().To<JumpStrategy>().AsSingle();
		Container.Bind<IDashStrategy>().To<DashStrategy>().AsSingle();

		// 2. Потом инстанцируем игрока
		var playerInstance = Container.InstantiatePrefabForComponent<CharacterController>(
			_playerPrefab, _spawnPoint.position, Quaternion.identity, null);

		// 3. И биндим сам контроллер (необязательно, если нигде не резолвишь напрямую)
		Container.Bind<CharacterController>().FromInstance(playerInstance).AsSingle();

		Debug.Log("[PlayerInstaller] Bindings complete.");
	}

}