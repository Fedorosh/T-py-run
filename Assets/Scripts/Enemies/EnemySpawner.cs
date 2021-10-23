using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPool[] enemyPool;
    private static EnemySpawner instance;
    public float spawnFrequency;
    float timer;
    public int seed;
    void Start()
    {
        instance = this;
        timer = 0;
        Random.InitState(seed);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnFrequency)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    public static void KillEnemy(Enemy enemy)
    {
        int i = (enemy.tag[enemy.tag.Length - 1] - '0') - 1;
        instance.enemyPool[i].InvokeEnemyDied(enemy);
    }

    public void SpawnEnemy()
    {
        int rand = Random.Range(0, 3);
        if (enemyPool[rand].transform.childCount <= 0) return;
            GameObject obj = enemyPool[rand].transform.GetChild(0).gameObject;
        obj.transform.SetParent(null);
        obj.transform.SetPositionAndRotation(enemyPool[rand].enemyStartPoint.position, enemyPool[rand].enemyStartPoint.rotation);
        obj.SetActive(true);
    }
}
