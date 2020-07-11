using UnityEngine;
using UnityEngine.UI;

public class StartSceneController : MonoBehaviour
{
	[SerializeField]
	private Button StartButton = null;

	private void Awake()
	{
		StartButton.onClick.AddListener(OnStartClick);
	}

	private void OnStartClick()
	{
		Application.App.ChangeSceneTo(Application.SceneName.Level);
	}
}
