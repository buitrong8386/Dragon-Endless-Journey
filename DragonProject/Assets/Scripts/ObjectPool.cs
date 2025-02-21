using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private Queue<GameObject> _gameObjects;
    void Awake()
    {
        _gameObjects = new Queue<GameObject>();
    }

    public GameObject GetObject()
    {
        if (_gameObjects.Count > 0)
        {
            var obj = _gameObjects.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            return Instantiate(prefab);
        }
    }
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        _gameObjects.Enqueue(obj);
    }
}
