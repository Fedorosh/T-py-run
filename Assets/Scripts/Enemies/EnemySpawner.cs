using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private readonly string[] enemyType = 
    { "FlyingEnemy","FlyingObject","Enemy","Object" };
    public float spawnFrequency;
    float timer;
    private int seed;
    void Start()
    {
        seed = Random.Range(0, 1001);
        timer = 0;
        Random.InitState(seed);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnFrequency)
        {
            SpawnEnemy();
            timer -= spawnFrequency;
        }
    }
    public void SpawnEnemy()
    {
        int rand = Random.Range(0, enemyType.Length);
        GameObject obj = Pool.instance.Get(enemyType[rand]);
        if(obj != null)
        {
            obj.transform.position = transform.position;
            obj.SetActive(true);
        }
    }
}
