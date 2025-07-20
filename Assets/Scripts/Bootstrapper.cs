using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Bootstrapper : IInitializable
{
    private readonly ISceneLoaderService _sceneLoader;

    public Bootstrapper(ISceneLoaderService sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    public void Initialize()
    {
        Debug.Log("[Bootstrapper] Initializing...");
        _sceneLoader.LoadNextScene();
    }
}
