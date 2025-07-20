using UnityEngine;
using UnityEngine.SceneManagement;

public interface ISceneLoaderService
{
    void LoadScene(string sceneName);
    void LoadScene(int sceneIndex);
    void LoadNextScene();
    void LoadPreviousScene();
    void LoadSceneAsync(string sceneName);
}

public class SceneLoaderService : MonoBehaviour, ISceneLoaderService
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(int sceneIndex)
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

    public void LoadSceneAsync(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
