using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Application : MonoBehaviour
{
	public static Application App { get; private set; }

	private void Awake()
	{
		DontDestroyOnLoad(this);
		App = this;
	}

	public void ChangeSceneTo(SceneName sceneIndex, int suffix = 0)
	{
		string sceneName;
	
		switch (sceneIndex)
		{
			case SceneName.Start:
				sceneName = "Start";
				break;
			case SceneName.Level:
				sceneName = $"Level{suffix}";
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(sceneIndex), sceneIndex, null);
		}

		SceneManager.LoadScene(sceneName);
	}

	public enum SceneName
	{
		Start = 0,
		Level
	}
}

