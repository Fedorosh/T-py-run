using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public Transform enemyStartPoint;
    public delegate void EnemyDied(Enemy enemy, bool byPlayer);
    public event EnemyDied OnEnemyDied;
    private void Awake()
    {
        OnEnemyDied += HandleDeadEnemy;
        OnEnemyDied += GameController.GetScoreOnEnemyDied;
    }

    public void InvokeEnemyDied(Enemy enemy, bool byPlayer)
    {
        OnEnemyDied?.Invoke(enemy,byPlayer);
    }
    private void HandleDeadEnemy(Enemy enemy, bool byPlayer)
    {
        enemy.transform.SetParent(transform);
        enemy.gameObject.SetActive(false);
    }
}
