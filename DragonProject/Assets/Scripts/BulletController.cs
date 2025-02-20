using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private ObjectPool _objectPool;
    void Start()
    {
        _objectPool = GetComponent<ObjectPool>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _objectPool.ReturnObject(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        _objectPool.ReturnObject(gameObject);
    }
}
