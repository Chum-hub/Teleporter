using UnityEngine;
using Zenject;
using Slider = UnityEngine.UI.Slider;
using Text = UnityEngine.UI.Text;

public abstract class Bootstrapper : IInitializable
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
		Debug.Log("[Bootstrapper] Initialized.");
	}
}

public class AnimationLoaderAsync
{
	private readonly ISceneLoaderService _sceneLoader;
	[SerializeField] private Slider _slider;
	[SerializeField] private Text _text;

	public AnimationLoaderAsync(ISceneLoaderService sceneLoader)
	{
		_sceneLoader = sceneLoader;
	}
}