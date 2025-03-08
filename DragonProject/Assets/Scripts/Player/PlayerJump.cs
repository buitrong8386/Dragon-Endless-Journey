using Contants;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float initialJumpForce;
    private Rigidbody2D rb;
    private bool canJump = false; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    private void Update()
    {
        // Kiểm tra nhảy trong Update
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * initialJumpForce);
        canJump = false; // Sau khi nhảy, không thể nhảy tiếp cho đến khi chạm đất
        //animator?.SetBool("Jump", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra va chạm với đất
        if (collision.gameObject.CompareTag(TagContants.BACKGROUND))
        {
            canJump = true; // Cho phép nhảy khi chạm đất
            //animator?.SetBool("Jump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Khi rời khỏi mặt đất
        if (collision.gameObject.CompareTag(TagContants.BACKGROUND))
        {
            canJump = false; // Không cho phép nhảy khi đang ở trên không
        }
    }
}
