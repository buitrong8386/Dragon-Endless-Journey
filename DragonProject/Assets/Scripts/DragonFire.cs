using Entity;
using UnityEngine;

public class DragonFire : MonoBehaviour
{

    private ObjectPool _objectPool;
    public Transform firePoint;
    public float delay;
    private float lastFire;
    void Start()
    {
        _objectPool = GetComponent<ObjectPool>();
        lastFire = 0f;
    }

    public void Fire(Direction direction)
    {
        if(lastFire + delay > Time.time)
        {
            return;
        }
        var bullet = _objectPool.GetObject();
        bullet.transform.position = firePoint.position;
        bullet.GetComponent<Rigidbody2D>().velocity = direction switch
        {
            Direction.Left => Vector2.left * 10f,
            Direction.Right => Vector2.right * 10f,
            _ => throw new System.ArgumentOutOfRangeException()
        };
        lastFire = Time.time;
    }
}
