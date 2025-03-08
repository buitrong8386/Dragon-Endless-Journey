using System.Collections;
using Contants;
using Entity;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player;
    public PanelManager panelManagerScript;
    public HealthBar healthBar;
    private bool isImmune;
    private float immunityDuration;
    void Start()
    {
        panelManagerScript = GameObject.Find("Canvas").GetComponent<PanelManager>();
        player = new Player
        {
            Name = "Player",
            Health = 100,
        };
        healthBar.UpdateHealthBar(player.Health, 100);
        isImmune = false;
        immunityDuration = 30f;
    }
    void Update()
    {
        CheckPosition();
    }

    public void TakeDamage(int damage)
    {
        if (isImmune && damage > 0)
        {
            return;
        }
        player.Health -= damage;
        if (player.Health > 100)
        {
            player.Health = 100;
        }
        healthBar.UpdateHealthBar(player.Health, 100);
        if (player.Health <= 0)
        {
            Death();
        }
    }

    void CheckPosition()
    {
        if (transform.position.y < -5.5f)
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
        if (collision.gameObject.tag == TagContants.HP)
        {
            TakeDamage(-20);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == TagContants.SECURITY)
        {
            ActivateImmunity();
            Destroy(collision.gameObject);
        }
    }
    private void ActivateImmunity()
    {
        if (!isImmune)
        {
            StartCoroutine(ImmunityTimer());
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(ImmunityTimer());
        }
    }

    private IEnumerator ImmunityTimer()
    {
        isImmune = true;
        yield return new WaitForSeconds(immunityDuration);
        isImmune = false;
    }

    void Death()
    {
        Destroy(gameObject);
        panelManagerScript.GameOver();
    }
}
