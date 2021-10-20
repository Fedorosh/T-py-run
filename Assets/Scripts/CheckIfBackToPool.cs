using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfBackToPool : MonoBehaviour
{
    private void GetMeBackToPool(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shot"))
        {
            GetMeBackToPool(collision.gameObject);
        }
    }
}
