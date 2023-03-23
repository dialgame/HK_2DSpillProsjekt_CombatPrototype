using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImagePool : MonoBehaviour
{
    [SerializeField] private GameObject afterImagePrefab;

    private Queue<GameObject> availableObjects = new Queue<GameObject>(); //used to store all objects that were made that are not currently active.
    
    //singleton
    public static AfterImagePool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        GrowPool();//growpool once, so that GOs are ready when needed
    }

    //Creates more gameobjects for the pool
    private void GrowPool()
    {
        for (int i= 0; i < 10; i++)//creates 10 objects because thats the value chosen.
        {
            GameObject instanceToAdd = Instantiate(afterImagePrefab);
            instanceToAdd.transform.SetParent(transform);//gameobject recreate as a child of the gameobject this script is Attached to.
            AddToPool(instanceToAdd);
        }
    }

    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availableObjects.Enqueue(instance);
    }

    public GameObject GetFromPool()
    {
        if(availableObjects.Count == 0)
        {
            GrowPool();//this means that if we are trying to get an afterimage object to spawn, and they are none available, we will make some more.
        }
         
        GameObject instance = availableObjects.Dequeue(); //this will take an object from the queue
        instance.SetActive(true); //when this happens, the onEnable function will get Called in our AfterImageSprite script.
        return instance;
    }
}
