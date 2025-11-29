using System;
using UnityEngine;
using Zenject;
using Slider = UnityEngine.UI.Slider;
using Text = UnityEngine.UI.Text;

public class Bootstrapper : MonoBehaviour
{
    private void Start()
    {
        var loader = FindFirstObjectByType<SceneLoaderService>();
        if (loader != null)
        {
            loader.LoadSceneAsyncWithProgress("MainMenu", progress =>
            {
                Debug.Log($"Progress: {progress}");
            });
        }
        else
        {
            Debug.LogError("SceneLoaderService not found!");
        }
    }
}