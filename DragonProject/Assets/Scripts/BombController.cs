using Contants;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagContants.BACKGROUND)
         || collision.gameObject.CompareTag(TagContants.PLAYER))
        {
            FindObjectOfType<ObjectPool>().ReturnObject(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        FindObjectOfType<ObjectPool>().ReturnObject(gameObject);
    }
}
