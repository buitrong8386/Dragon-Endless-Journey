using Contants;
using UnityEngine;

public class PlaneBomb : MonoBehaviour
{
    private ObjectPool _objectPool;
    public Transform _transform;
    private Transform playerTransform;
    [SerializeField] private float bulletSpeed;
    private float lastFire;
    public float delay;
    private GameObject player;
    void Start()
    {
        _objectPool = GetComponent<ObjectPool>();
        bulletSpeed = 10f;
        playerTransform = GameObject.FindGameObjectWithTag(TagContants.PLAYER).transform;
        lastFire = 0f;
        player = GameObject.FindGameObjectWithTag(TagContants.PLAYER);
    }

    public void Bomb()
    {
        if (player == null)
        {
            return;
        }
        if (lastFire + delay > Time.time)
        {
            return;
        }
        var bomb = _objectPool.GetObject();
        bomb.transform.position = _transform.position;
        Vector2 direction = ((Vector2)playerTransform.position - (Vector2)_transform.position).normalized;
        Rigidbody2D rb = bomb.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bomb.transform.rotation = Quaternion.Euler(0, 0, angle);
        lastFire = Time.time;
    }
}
