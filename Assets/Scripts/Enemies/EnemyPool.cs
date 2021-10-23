using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public Transform enemyStartPoint;
    public delegate void EnemyDied(Enemy enemy);
    public event EnemyDied OnEnemyDied;
    private void Awake()
    {
        OnEnemyDied += HandleDeadEnemy;
    }

    public void InvokeEnemyDied(Enemy enemy)
    {
        OnEnemyDied?.Invoke(enemy);
    }

    private void HandleDeadEnemy(Enemy enemy)
    {
        enemy.transform.SetParent(transform);
        enemy.gameObject.SetActive(false);
    }
}
