using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float moveSpeed = 5f;

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
