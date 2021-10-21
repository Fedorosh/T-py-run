using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfBackToPool : MonoBehaviour
{
    public delegate void BackToPool(GameObject obj);
    public static event BackToPool OnBackToPool;

    private void Awake()
    {
        OnBackToPool += GetMeBackToPool;
    }
    private void GetMeBackToPool(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform);
    }

    public static void InvokeBackToPool(GameObject obj)
    {
        OnBackToPool?.Invoke(obj);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shot"))
        {
            OnBackToPool?.Invoke(collision.gameObject);
        }
    }
}
