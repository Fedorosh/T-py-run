using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Vector3 groundPos;

    private readonly string[] enemyType = 
    { "FlyingEnemy","FlyingObject","Enemy","Object" };
    private int seed;
    void Start()
    {
        seed = Random.Range(0, 1001);
        Random.InitState(seed);
    }

    void Update()
    {
        if (Random.Range(0,1000) < 10)
        {
            SpawnEnemy();
        }
    }
    public void SpawnEnemy()
    {
        int rand = Random.Range(0, enemyType.Length);
        GameObject obj = Pool.instance.Get(enemyType[rand]);
        if(obj != null)
        {
            obj.transform.position = transform.position;
            if (!enemyType[rand].Contains("Flying")) obj.transform.position += groundPos;
            obj.SetActive(true);
        }
    }
}
