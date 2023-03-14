using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
