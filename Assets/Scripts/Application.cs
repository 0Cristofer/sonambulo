using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Application : MonoBehaviour
{
	private bool FinishedLevel { get; set; }
	public static Application App { get; private set; }

	private void Awake()
	{
		if (FindObjectsOfType<Application>().Length > 1)
			Destroy(gameObject);
		
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
	
	public void WinLevel()
	{
		//todo: mostrar overlay de "ganhou" com textinho pra apertar qualquer tecla pra prosseguir pro próximo level

		FinishedLevel = true;
	}

	private void LateUpdate()
	{
		if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
		if (FinishedLevel && Input.GetKeyDown(KeyCode.Return)) NextLevel();
	}

	private void NextLevel()
	{
		string currentLevel = SceneManager.GetActiveScene().name;
		int levelNumber = int.Parse(currentLevel.Substring(currentLevel.Length - 1)) + 1;
		App.ChangeSceneTo(SceneName.Level, levelNumber);
		FinishedLevel = false;
	}

	public enum SceneName
	{
		Start = 0,
		Level
	}
}

