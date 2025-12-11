using Input;
using ScriptableObjects;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Installers
{
	[CreateAssetMenu (fileName = "GameSystemInstaller",
		menuName = "installers/New GameSystemInstaller")]

	public class GameSystemInstaller : ScriptableObjectInstaller
	{
		public override void InstallBindings()
		{
			
		}
	}
}