using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isAlive = false;
    public bool isObstacle = false;
    public float speed;
    private void Kill(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Shot"))
        {
            if(!isObstacle)
            {
                CheckIfBackToPool.InvokeBackToPool(collision.gameObject);
                EnemyPool.InvokeEnemyDied(this);
            }
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("DeathWall"))
        {
            EnemyPool.InvokeEnemyDied(this);

        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Kill(collision);
        }
    }

    private void OnEnable()
    {
        isAlive = true;   
    }

    private void OnDisable()
    {
        isAlive = false;
    }

    private void Update()
    {
        if(isAlive)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed,Space.World);
        }
    }
}
