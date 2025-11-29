using Zenject;
using UnityEngine;

namespace Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private MovementSetting _movementSetting;
        public override void InstallBindings()
        {
            Debug.Log("[ProjectInstaller] Installing global bindings...");

            Container.Bind<MovementSetting>()
            .FromInstance(_movementSetting)
            .AsSingle();

            Debug.Log("[ProjectInstaller] Global bindings complete.");
        }
    }
}