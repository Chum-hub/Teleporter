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
		[SerializeField]
		private GameObject _head;
		[SerializeField]
		private Transform _characterTransform;
		[SerializeField]
		private Rigidbody _rb;
		public override void InstallBindings()
		{
			Debug.Log("[PlayerInstaller] Installing player-specific bindings...");
			
			
			Container
				.Bind<GameObject>()
				.FromInstance(_head)
				.AsSingle();
			
			Container
				.Bind<Transform>()
				.FromInstance(_characterTransform)
				.AsSingle();

			Container
				.Bind<Rigidbody>()
				.FromInstance(_rb)
				.AsSingle();
			
			
			Debug.Log("[PlayerInstaller] Bindings complete.");
		}
	}
}