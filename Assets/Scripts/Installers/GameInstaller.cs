using UnityEngine;
using Zenject;

namespace Installers
{
	public class GameInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Debug.Log("[GameInstaller] Installing Game-specific bindings...");
			Debug.Log("[GameInstaller] Bindings complete.");
		}
	}
}
