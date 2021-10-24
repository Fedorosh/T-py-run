using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public delegate void PlayerDied();
    public static event PlayerDied OnPlayerDied;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject player;
    [SerializeField] private Button[] controls;
    void Start()
    {
        OnPlayerDied += PauseOnPlayerDied;
    }

    public static void InvokePlayerDied()
    {
        OnPlayerDied?.Invoke();
    }

    public void OnRetryClicked()
    {
        gameOverScreen.SetActive(false);
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
        enemyList.ForEach((x) => EnemySpawner.KillEnemy(x));
    }

    private void PauseOnPlayerDied()
    {
        gameOverScreen.SetActive(true);
        foreach (var x in controls)
        {
            x.GetComponent<EventTrigger>().enabled = false;
            x.interactable = false;
        }
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
