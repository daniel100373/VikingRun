using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    
    public void LoadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadHelpScene()
    {
        SceneManager.LoadScene(3);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    
}
