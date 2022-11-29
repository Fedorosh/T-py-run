using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isAlive = false;
    public bool isObstacle = false;
    public float speed;
    public int score = 100;
    private void Kill(Collider2D collision)
    {
        GameController.InvokePlayerDied();
        collision.gameObject.SetActive(false);
    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Shot"))
        {
            CheckIfBackToPool.InvokeBackToPool(collision.gameObject);
            if (!isObstacle)
            {
                gameObject.SetActive(false);
            }
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
