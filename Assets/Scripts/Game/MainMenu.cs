using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int sceneIndex = 1;
    public void StartGame()
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void EnableDisableSound(bool sound)
    {
        AudioListener.pause = !sound;
    }
}
