using Data;
using Interfaces;
using Player;
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
		private Character _character;
		

		public override void InstallBindings()
		{
			Debug.Log("[SceneInstaller] Installing Game-specific bindings...");
			
			Container
				.Bind<CinemachineCamera>()
				.FromInstance(_camera)
				.AsSingle();

			Container
				.Bind<CharacterState>()
				.AsSingle();

			Container
				.Bind<CharacterLookData>()
				.AsSingle();

			Container
				.Bind<Character>()
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
				.BindInterfacesAndSelfTo<CharacterControllerService>()
				.AsSingle();
			
			Debug.Log("[SceneInstaller] Bindings complete.");
		}
	}
}
