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

            Container.Bind<MovementSetting>().FromInstance(_movementSetting).AsSingle();
            
            //Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneLoaderService>().FromNewComponentOnNewGameObject().AsSingle();
            Container.BindInterfacesAndSelfTo<Bootstrapper>().AsSingle();

            Debug.Log("[ProjectInstaller] Global bindings complete.");
        }
    }
}