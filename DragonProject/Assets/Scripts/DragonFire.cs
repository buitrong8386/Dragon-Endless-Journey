using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFire : MonoBehaviour
{

    private ObjectPool _objectPool;
    public Transform firePoint;
    void Start()
    {
        _objectPool = GetComponent<ObjectPool>();
    }

    public void Fire()
    {
        var bullet = _objectPool.GetObject();
        bullet.transform.position = firePoint.position;
        bullet.GetComponent<Rigidbody2D>().velocity = firePoint.right * 10f;
    }
}
