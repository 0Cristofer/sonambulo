using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private bool FinishedLevel { get; set; }
    
    public void LoseLevel()
    {
        //todo: mostrar overlay de "perdeu" com textinho pra apertar R pra recomeçar
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
    
    public void NextLevel()
    {
        string currentLevel = SceneManager.GetActiveScene().name;
        int levelNumber = int.Parse(currentLevel.Substring(currentLevel.Length - 1)) + 1;
        Application.App.ChangeSceneTo(Application.SceneName.Level, levelNumber);
    }
}
