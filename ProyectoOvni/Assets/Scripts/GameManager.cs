using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    

    public void LoadStartMenu()
    {
        
    }


    public void LoadGame()
    {
      SceneManager.LoadScene("MainGame");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void LoadWin()
    {
        SceneManager.LoadScene("Win");
    }

    public void QuitGame()
    {
        Application.Quit();

    }

}
