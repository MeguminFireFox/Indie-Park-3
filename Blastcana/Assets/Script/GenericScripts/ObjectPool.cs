using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;


//Instancie la liste des projectiles à stocker.
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject PrefabPooled;
        for (int i = 0; i < amountToPool; i++)
        {
            PrefabPooled = Instantiate(objectToPool);
            PrefabPooled.SetActive(false);
            pooledObjects.Add(PrefabPooled);
        }
    }

    // Permet de référencer les objets dans la pool.
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                
                return pooledObjects[i];
                
            }
        }
        return null;
    }
}
