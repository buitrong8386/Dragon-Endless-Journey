using Contants;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public BombData _bombData;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagContants.BACKGROUND) || collision.gameObject.CompareTag(TagContants.TRAP))
        {
            FindObjectOfType<ObjectPool>().ReturnObject(gameObject);
        }
        if (collision.gameObject.CompareTag(TagContants.PLAYER))
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            if (playerController != null)
            {
                FindObjectOfType<ObjectPool>().ReturnObject(gameObject);
                playerController.TakeDamage(_bombData.value);
            }
        }
    }

    private void OnBecameInvisible()
    {
        FindObjectOfType<ObjectPool>().ReturnObject(gameObject);
    }
}
