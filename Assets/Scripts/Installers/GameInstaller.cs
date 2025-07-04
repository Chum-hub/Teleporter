using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
	[SerializeField] private MovementSetting _movementSetting;


	public override void InstallBindings()
	{
		Debug.Log("[GameInstaller] Installing Game-specific bindings...");
		
		Container.Bind<MovementSetting>().FromInstance(_movementSetting).AsSingle();
		
		Debug.Log("[GameInstaller] Bindings complete.");
	}
}
