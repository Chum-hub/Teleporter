using Input;
using ScriptableObjects;
using Timer;
using Zenject;
using UnityEngine;
using Object = System.Object;

namespace Installers
{
	public class ProjectInstaller : MonoInstaller
	{
		[SerializeField]private MovementSetting _setting;

		public override void InstallBindings()
		{
			Debug.Log("[ProjectInstaller] Installing global bindings...");

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
			
			Debug.Log("[ProjectInstaller] Global bindings complete.");
		}
	}
}