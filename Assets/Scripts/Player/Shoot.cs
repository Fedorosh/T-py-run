using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;

    public void PerformShoot()
    {
        GameObject obj = Pool.instance.Get("Shot");
        if (obj != null)
        {
            obj.transform.position = shootPoint.position;
            obj.gameObject.SetActive(true);

        }//Perform 
    }
}
