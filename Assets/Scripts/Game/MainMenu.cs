using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public int sceneIndex = 1;
    private int soundOn;
    public Toggle sound;

    [SerializeField] TextMeshProUGUI infoText;
    public void StartGame()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private void Start()
    {
        soundOn = PlayerPrefs.GetInt("SoundOn", 1);
        sound.isOn = soundOn == 1 ? true : false;
    }

    public void ClearScores()
    {
        if(!PlayerPrefs.HasKey("HighScore"))
        {
            if (!infoText.gameObject.activeSelf) infoText.gameObject.SetActive(true);
            infoText.text = "No Scores to delete.";
            return;
        }
        PlayerPrefs.DeleteKey("HighScore");
        if (!infoText.gameObject.activeSelf) infoText.gameObject.SetActive(true);
        infoText.text = "Scores Cleared!";
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void EnableDisableSound(bool sound)
    {
        AudioListener.pause = !sound;
        soundOn = AudioListener.pause ? 0 : 1; 
        PlayerPrefs.SetInt("SoundOn", soundOn);

    }
}
