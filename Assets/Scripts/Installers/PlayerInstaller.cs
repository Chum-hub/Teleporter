using Input;
using Interfaces;
using Player;
using ScriptableObjects;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Installers
{
	public class PlayerInstaller : MonoInstaller
	{
		
		public override void InstallBindings()
		{
			Debug.Log("[PlayerInstaller] Installing player-specific bindings...");
			
			

			Debug.Log("[PlayerInstaller] Bindings complete.");
		}
	}
}