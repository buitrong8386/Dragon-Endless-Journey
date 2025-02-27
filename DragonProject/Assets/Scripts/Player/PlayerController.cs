using Contants;
using Entity;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player;
    private PanelManager panelManagerScript;
    void Start()
    {
        panelManagerScript = GameObject.Find("Canvas").GetComponent<PanelManager>();
        player = new Player
        {
            Name = "Player",
            Health = 100,
        };
    }
    void Update()
    {
        CheckPosition();
    }

    public void TakeDamage(int damage)
    {
        player.Health -= damage;
        Debug.Log(this.transform.position.y);
        if (player.Health <= 0)
        {
            Death();
        }
    }

    void CheckPosition()
    {
        if (this.transform.position.y < -5.5f)
        {
            Death();
        }
    }
        public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == TagContants.TRAP)
        {
            Destroy(collision.gameObject.GetComponent<BoxCollider2D>());
          
        }
    }

    
    void Death()
    {
        Destroy(gameObject);
        panelManagerScript.GameOver();
    }
}
