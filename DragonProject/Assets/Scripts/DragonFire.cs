using System.Collections;
using System.Collections.Generic;
using Entity;
using UnityEngine;

public class DragonFire : MonoBehaviour
{

    private ObjectPool _objectPool;
    public Transform firePoint;
    void Start()
    {
        _objectPool = GetComponent<ObjectPool>();
    }

    public void Fire(Direction direction)
    {
        var bullet = _objectPool.GetObject();
        bullet.transform.position = firePoint.position;
        bullet.GetComponent<Rigidbody2D>().velocity = direction switch
        {
            Direction.Left => Vector2.left * 10f,
            Direction.Right => Vector2.right * 10f,
            _ => throw new System.ArgumentOutOfRangeException()
        };
    }
}
