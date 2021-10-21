using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyPool enemyPool;
    public float spawnFrequency;
    float timer;
    void Start()
    {
        timer = 0;
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

    public void SpawnEnemy()
    {
        if (enemyPool.transform.childCount <= 0) return;
            GameObject obj = enemyPool.transform.GetChild(0).gameObject;
        obj.transform.SetParent(null);
        obj.transform.SetPositionAndRotation(enemyPool.enemyStartPoint.position, enemyPool.enemyStartPoint.rotation);
        obj.SetActive(true);
    }
}
