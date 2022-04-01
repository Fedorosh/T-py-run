using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum Musics
{
    gameplay,
    gameOver
}

public class GameController : MonoBehaviour
{
    public delegate void PlayerDied();
    public static event PlayerDied OnPlayerDied;

    private static GameController instance;
    private AudioSource source;
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject player;
    [SerializeField] private Button[] controls;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreTextOnGameOver;
    [SerializeField] private GameObject highScoreText;

    public float timeScaler = 0.001f;

    private int bestScore;

    private bool isPlaying = true;
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("HighScore",0);
        instance = this;
        source = GetComponent<AudioSource>();
        OnPlayerDied += PauseOnPlayerDied;
        OnPlayerDied += ChangeMusicOver;
    }

    public static void GetScoreOnEnemyDied(Enemy enemy, bool byPlayer)
    {
        if(byPlayer)
            if(enemy.score != 0)
            {
                int i = int.Parse(Regex.Match(instance.scoreText.text, @"\d+").Value);
                instance.scoreText.text = string.Format("Score: {0}", i + enemy.score);
            }
    }

    public static void InvokePlayerDied()
    {
        OnPlayerDied?.Invoke();
    }

    public void ChangeMusicOver()
    {
        if (source.isPlaying) source.Stop();
        source.clip = clips[(int)Musics.gameOver];
        source.loop = false;
        source.Play();
    }

    public void ChangeMusicPlay()
    {
        if (source.isPlaying) source.Stop();
        source.clip = clips[(int)Musics.gameplay];
        source.loop = true;
        source.Play();
    }

    public void OnRetryClicked()
    {
        gameOverScreen.SetActive(false);
        isPlaying = true;
        scoreText.gameObject.SetActive(true);
        player.SetActive(true);
        foreach (var x in controls)
        {
            x.GetComponent<EventTrigger>().enabled = true;
            x.interactable = true;
        }
        KillAllEnemies();
        ChangeMusicPlay();
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnApplicationPause()
    {
        PlayerPrefs.SetInt("HighScore", bestScore);
    }


    private void KillAllEnemies()
    {
        List<Enemy> enemyList = new List<Enemy>();
        foreach(var x in FindObjectsOfType<Enemy>())
        {
            if (x.transform.parent == null) enemyList.Add(x);
        }
        enemyList.ForEach((x) => EnemySpawner.KillEnemy(x, false));
    }

    private void PauseOnPlayerDied()
    {
        gameOverScreen.SetActive(true);
        isPlaying = false;
        scoreTextOnGameOver.text = "Your " + scoreText.text;
        int potentialBest = int.Parse(Regex.Match(scoreText.text, @"\d+").Value);
        if(potentialBest > bestScore) 
        {
            bestScore = potentialBest;
            highScoreText.SetActive(true);
        }
        else if(highScoreText.activeSelf) highScoreText.SetActive(false);
        scoreText.text = "Score: 0";
        scoreText.gameObject.SetActive(false);
        foreach (var x in controls)
        {
            x.GetComponent<EventTrigger>().enabled = false;
            x.interactable = false;
        }
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if(isPlaying)
        {
            Time.timeScale += Time.unscaledDeltaTime * timeScaler;
        }
        Debug.Log(Time.timeScale);
    }
}
