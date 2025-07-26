using UnityEngine;
using Zenject;
using Slider = UnityEngine.UI.Slider;
using Text = UnityEngine.UI.Text;

public class Bootstrapper : MonoBehaviour
{
    private void Start()
    {
        // Найти SceneLoaderService на Canvas (по типу или тегу)
        var loader = FindObjectOfType<SceneLoaderService>();
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