using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] GameObject objectPrefab;

    private Queue<GameObject> gameObjectsPool = new Queue<GameObject>();
    public static ObjectPooling instance = null;

    private void Awake()
    {
        if(instance==null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject GetFromPool()
    {
        if(gameObjectsPool.Count==0)
        {
            AddGameObjects(1);
        }

        return gameObjectsPool.Dequeue();
    }

    private void AddGameObjects(int countGameObjects)
    {
        for(int i=0;i<countGameObjects;i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            gameObjectsPool.Enqueue(obj);
        }
    }

    public void ReturnToPool(GameObject returningGameObject)
    {
        returningGameObject.SetActive(false);
        gameObjectsPool.Enqueue(returningGameObject);
    }
}
