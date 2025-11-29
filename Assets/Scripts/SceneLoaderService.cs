using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Interfaces;
using System;

public class SceneLoaderService : MonoBehaviour, ISceneLoaderService
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;

    public void LoadScene(String sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(Int32 sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void LoadSceneAsync(String sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void LoadSceneAsyncWithProgress(String sceneName, Action<Single> onProgress)
    {
        StartCoroutine(LoadSceneAsyncCoroutine(sceneName, onProgress));
    }

    private IEnumerator LoadSceneAsyncCoroutine(String sceneName, Action<Single> onProgress)
    {
        var op = SceneManager.LoadSceneAsync(sceneName);
        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            var progress = Mathf.Clamp01(op.progress / 0.9f);
            onProgress?.Invoke(progress);
            _slider.value = progress;
            _text.text = $"Loading... {(Int32)(progress * 100)}%";
            if (op.progress >= 0.9f)
            {
                onProgress?.Invoke(1f);
                op.allowSceneActivation = true;
                _slider.value = 1f;
                _text.text = "Yeah its 100% let me sec...";
                yield return new WaitForSeconds(2f);
            }
            yield return null;
        }
    }
}
