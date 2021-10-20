using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject pool;
    public float shootSpeed;
    void Start()
    {
        
    }

    public bool IsInPool()
    {
        if (pool.transform.childCount > 0)
            return true;
        return false;
    }

    public void PerformShoot()
    {
        if (IsInPool())
        {
            Rigidbody2D rb = pool.transform.GetChild(0).GetComponent<Rigidbody2D>();
            rb.gameObject.SetActive(true);
            rb.transform.SetParent(null);
            rb.transform.SetPositionAndRotation(transform.position, transform.rotation);
            rb.AddForce(new Vector2(shootSpeed, 0),ForceMode2D.Impulse);

        }//Perform 
    }
    void Update()
    {
        
    }
}
