using Input;
using Interfaces;
using Player;
using ScriptableObjects;
using Timer;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

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
				.Bind<CooldownTimer>()
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
			
			Container
				.Bind<ICharacterDash>()
				.To<CharacterDash>()
				.AsSingle();


			Container
				.Bind<ICharacterJump>()
				.To<CharacterJump>()
				.AsSingle();

			Container
				.Bind<ICharacterLook>()
				.To<CharacterLook>()
				.AsSingle();

			Container
				.Bind<ICharacterMove>()
				.To<CharacterMove>()
				.AsSingle();

			Container
				.BindInterfacesAndSelfTo<PlayerControllerService>()
				.AsSingle();
			
			Debug.Log("[SceneInstaller] Bindings complete.");
		}
	}
}
