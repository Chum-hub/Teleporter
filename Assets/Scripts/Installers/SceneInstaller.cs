using Input;
using Interfaces;
using Player;
using ScriptableObjects;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;
using Object = System.Object;

namespace Installers
{
	public class SceneInstaller : MonoInstaller
	{
		[SerializeField]
		private CinemachineCamera _camera;
		[SerializeField]
		private Transform _transform;
		[SerializeField]
		private Rigidbody _rb;
		[SerializeField]
		private Character _character;
		[SerializeField]
		private MovementSetting _setting;
		[SerializeField]
		private GameObject _head;

		public override void InstallBindings()
		{
			Debug.Log("[SceneInstaller] Installing Game-specific bindings...");

			Container
				.Bind<MovementSetting>()
				.FromInstance(_setting)
				.AsSingle();

			Container
				.BindInterfacesAndSelfTo<PlayerInputCache>()
				.AsSingle();

			Container
				.Bind<Timer.Timer>()
				.AsTransient();

			Container
				.Bind<GameObject>()
				.FromInstance(_head)
				.AsSingle();
			
			Container
				.Bind<Transform>()
				.FromInstance(_transform)
				.AsSingle();

			Container
				.Bind<Rigidbody>()
				.FromInstance(_rb)
				.AsSingle();

			Container
				.Bind<CinemachineCamera>()
				.FromInstance(_camera)
				.AsSingle();

			Container
				.Bind<CharacterState>()
				.AsSingle();

			Container
				.Bind<ICharacter>()
				.FromInstance(_character)
				.AsSingle();

			// Container
			// 	.Bind<PlayerContext>()
			// 	.AsSingle();
			
			Container
				.Bind<IDashStrategy>()
				.To<DashStrategy>()
				.AsSingle();


			Container
				.Bind<IJumpStrategy>()
				.To<JumpStrategy>()
				.AsSingle();

			Container
				.Bind<ILookStrategy>()
				.To<LookStrategy>()
				.AsSingle();

			Container
				.Bind<IMovementStrategy>()
				.To<WalkMovementStrategy>()
				.AsSingle();

			Container
				.BindInterfacesAndSelfTo<PlayerControllerService>()
				.AsSingle();
			
			Debug.Log("[SceneInstaller] Bindings complete.");
		}
	}
}
