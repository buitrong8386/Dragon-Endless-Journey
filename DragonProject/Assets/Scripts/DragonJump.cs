using UnityEngine;

public class DragonJump : MonoBehaviour
{
    public float initialJumpForce = 1000f;
    public float holdJumpForce = 200f;  // Lực nhảy thêm khi giữ phím
    public float maxHoldJumpTime = 0.35f;  // Thời gian tối đa có thể giữ phím nhảy
    public float moveSpeed = 5f;
    public bool isGrounded;
    private Rigidbody2D rb;
    private Animator animator;

    // Biến để kiểm soát nhảy
    private bool isHoldingJump;
    private float holdJumpTimer;
    private bool canAddHoldForce = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Cấu hình Rigidbody2D
        rb.gravityScale = 3f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    private void Update()
    {
        HandleJump();
    }

    private void HandleJump()
    {
        // Bắt đầu nhảy
        if (isGrounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {

            rb.AddForce(Vector2.up * initialJumpForce);
            isGrounded = false;
            isHoldingJump = true;
            holdJumpTimer = 0f;
            canAddHoldForce = true;
            animator?.SetBool("Jump", true);
        }

        // Xử lý giữ phím nhảy
        if (isHoldingJump && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
        {
            Debug.Log("Key hold");
            holdJumpTimer += Time.deltaTime;

            // Thêm lực nhảy khi giữ phím và trong thời gian cho phép
            if (holdJumpTimer <= maxHoldJumpTime && canAddHoldForce && rb.velocity.y > 0)
            {
                rb.AddForce(Vector2.up * holdJumpForce * Time.deltaTime);
            }
            else
            {
                canAddHoldForce = false;
            }
        }

        // Kết thúc nhảy khi thả phím
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            Debug.Log("Key up");
            isHoldingJump = false;
            canAddHoldForce = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BackGround"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                // Kiểm tra va chạm từ phía dưới
                if (contact.normal.y > 0.7f)
                {
                    isGrounded = true;
                    isHoldingJump = false;
                    canAddHoldForce = false;
                    holdJumpTimer = 0f;
                    animator?.SetBool("Jump", false);
                    break;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BackGround"))
        {
            isGrounded = false;
        }
    }
}