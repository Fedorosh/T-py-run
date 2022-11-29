using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float shootSpeed;

    public void PerformShoot()
    {
        GameObject obj = Pool.instance.Get("Shot");
        if (obj != null)
        {
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            rb.gameObject.SetActive(true);
            rb.transform.SetPositionAndRotation(transform.position, transform.rotation);
            rb.AddForce(new Vector2(shootSpeed / Time.timeScale, 0),ForceMode2D.Impulse);

        }//Perform 
    }
}
