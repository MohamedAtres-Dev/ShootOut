using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singlton<PoolManager>
{


    public List<ItemToPool> allObjects;     //make a list of item to pool

    public bool isExpand;                   //check if its expandable

    public List<GameObject> pooledObjects;


    public Transform levelManager;

    //public GameObject testObject;



    private void Start()
    {
        pooledObjects = new List<GameObject>();

        //this to make the container
        foreach (ItemToPool item in allObjects)
        {
            GameObject go = Instantiate(item.pool);



            go.transform.parent = levelManager;




            go.SetActive(false);
            pooledObjects.Add(go);
        }
    }


    //this to get an object fram a pool
    public GameObject GetPooledObject(string tag)
    {
        // control this to get random object to active again  = Done
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            

            if (pooledObjects[i].activeInHierarchy == false && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }
        }


        if (isExpand)
        {
            //GameObject[] randomObject = RandomList();

            // contol this to get a random object to instatiate again
            foreach (GameObject item in pooledObjects)
            {
                if (item.tag == tag)
                {
                    GameObject go = Instantiate(item);
                    go.SetActive(false);

                    pooledObjects.Add(go);
                    return go;
                }
            }

        }


        return null;
    }

    private int GenerateRandom()
    {
        int j = Random.Range(21, 22);
        return j;
    }


    //private GameObject[] RandomList()
    //{
    //    //control this to random inital objects
    //    foreach (ItemToPool obj in allObjects)
    //    {
    //        pooledObjects.Add(obj.pool);
    //    }

    //    GameObject[] randomArray = pooledObjects.ToArray();

    //    for (int i = 0; i < pooledObjects.Count; i++)
    //    {
    //        int k = Random.Range(0, pooledObjects.Count);
    //        GameObject temp = randomArray[k];
    //        randomArray[k] = randomArray[i];
    //        randomArray[i] = temp;
    //    }
    //    return randomArray;

    //}

}

[System.Serializable]
public class ItemToPool
{
    public GameObject pool;
    public int size;
}

