using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void starGame() 
    {
        SceneManager.LoadScene("Main Game");
    }

    public void closeGame()
    { 
        Application.Quit();
    }

}
