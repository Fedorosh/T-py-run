using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class PoolItem
{
    public GameObject prefab;
    public int amount;
    public bool expandable;
}
public class Pool : MonoBehaviour
{
    public static Pool instance;
    public List<PoolItem> items;
    public List<GameObject> pooledItems;

    private void Awake()
    {
        instance = this;
    }
    public GameObject Get(string tag)
    {
        for (int i = 0; i < pooledItems.Count; i++)
        {
            if (pooledItems[i].tag == tag && !pooledItems[i].activeInHierarchy)
            {
                return pooledItems[i];
            }
        }
        PoolItem item = items.FirstOrDefault(x => x.prefab.tag == tag && x.expandable);
        if (item != null)
        {
            GameObject obj = Instantiate(item.prefab);
            obj.SetActive(false);
            pooledItems.Add(obj);
            return obj;
        }
        return null;
    }

    private void Start()
    {
        pooledItems = new List<GameObject>();
        foreach (PoolItem item in items)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                pooledItems.Add(obj);
            }
        }
    }

}

