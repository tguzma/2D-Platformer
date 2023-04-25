using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI score;

    private void Start()
    {
        if (score != null)
        {
            var time = ScoreHandler.GetTime();
            score.text =
                $"Time: {Math.Round(time.TotalMinutes,0)}m {Math.Round(time.TotalSeconds,0)}s\nDeaths: {ScoreHandler.GetDeaths()}\nScore: {ScoreHandler.CalculateScore()}";
        }
    }

    public void LoadFirstLevel()
    {
        ScoreHandler.Start(TimeSpan.FromHours(1));
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
