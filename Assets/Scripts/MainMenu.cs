using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI score;

    private void Start()
    {
        ScoreHandler.InitArcade();

        if (score != null)
        {
            var time = ScoreHandler.GetTime();
            score.text =
                $"Time: {time.Minutes,0}m {time.Seconds,0}s\n" +
                $"Coins: {ScoreHandler.GetCollected()}/20\n" +
                $"Deaths: {ScoreHandler.GetDeaths()}\n" +
                $"Arcade: {ScoreHandler.GetArcade()}\n" +
                $"Score: {ScoreHandler.CalculateScore()}";
        }
    }

    public void LoadFirstLevel()
    {
        ScoreHandler.Start(TimeSpan.FromHours(1));
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

    public void SetArcade()
    {
        ScoreHandler.SetArcade();
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
