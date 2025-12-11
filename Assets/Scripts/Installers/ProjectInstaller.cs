using Input;
using Zenject;
using UnityEngine;

namespace Installers
{
	public class ProjectInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Debug.Log("[ProjectInstaller] Installing global bindings...");


			
			Debug.Log("[ProjectInstaller] Global bindings complete.");
		}
	}
}