using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool = 50;
    public int bulletID;
    public GameObject[] AllBullets;
    void Start()
    {
        AllBullets = Resources.LoadAll<GameObject>("Bullets");
        for (int i = 0; i < AllBullets.Length; i++)
        {
            if (PlayerPrefs.GetInt("EquipItemID") == i)
            {
                objectToPool = AllBullets[i];
            }
        }
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetBullet()
    {
        if (bulletID == amountToPool - 1)
        {
            bulletID = 1;
        }
        bulletID++;
        return pooledObjects[bulletID];
        
    }

    
}
