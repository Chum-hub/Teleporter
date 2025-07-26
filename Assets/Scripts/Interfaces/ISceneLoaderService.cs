using System;

namespace Interfaces
{
	public interface ISceneLoaderService
	{
		void LoadScene(string sceneName);
		void LoadScene(int sceneIndex);
		void LoadNextScene();
		void LoadPreviousScene();
		void LoadSceneAsync(string sceneName);
		void LoadSceneAsyncWithProgress(string sceneName, Action<float> onProgress);
	}
}