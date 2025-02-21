using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            FindObjectOfType<ObjectPool>().ReturnObject(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        FindObjectOfType<ObjectPool>().ReturnObject(gameObject);
    }
}
