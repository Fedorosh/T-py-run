using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public delegate void PlayerDied();
    public static event PlayerDied OnPlayerDied;

    private static GameController instance;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject player;
    [SerializeField] private Button[] controls;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreTextOnGameOver;
    void Start()
    {
        instance = this;
        OnPlayerDied += PauseOnPlayerDied;
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

    public void OnRetryClicked()
    {
        gameOverScreen.SetActive(false);
        scoreText.gameObject.SetActive(true);
        player.SetActive(true);
        foreach (var x in controls)
        {
            x.GetComponent<EventTrigger>().enabled = true;
            x.interactable = true;
        }
        KillAllEnemies();
        Time.timeScale = 1f;
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
        scoreTextOnGameOver.text = "Your " + scoreText.text;
        scoreText.text = "Score: 0";
        scoreText.gameObject.SetActive(false);
        foreach (var x in controls)
        {
            x.GetComponent<EventTrigger>().enabled = false;
            x.interactable = false;
        }
        Time.timeScale = 0f;
    }
}
