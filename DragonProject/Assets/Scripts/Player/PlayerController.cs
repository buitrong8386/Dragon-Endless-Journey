using Entity;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player;
    void Start()
    {
        player = new Player
        {
            Name = "Player",
            Health = 100,
        };
    }

    public void TakeDamage(int damage)
    {
        player.Health -= damage;
        if (player.Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
