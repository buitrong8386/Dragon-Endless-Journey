using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] private float verticalMoveSpeed = 3f; // Tốc độ di chuyển lên xuống
    [SerializeField] private float verticalDistance = 4f; // Khoảng cách di chuyển lên xuống
    [SerializeField] private float waitTime = 10f; // Thời gian chờ mỗi lần đến đích
    private Vector2 startPosition; // Vị trí ban đầu
    private Vector2 endPosition; // Vị trí cuối
    private bool movingDown = true; // Trạng thái đang di chuyển xuống
    private bool waiting = false; // Kiểm tra xem có đang chờ hay không
    private float waitTimer = 0f; // Bộ đếm thời gian chờ
    private PlaneBomb planeBomb;
    void Start()
    {
        startPosition = transform.position; // Lấy vị trí ban đầu
        endPosition = startPosition + Vector2.down * verticalDistance; // Lấy vị trí cuối
        planeBomb = GetComponent<PlaneBomb>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector2)transform.position == endPosition)
        {
            planeBomb.Bomb();
        }
        if (waiting)
        {
            waitTimer += Time.deltaTime; // Tăng bộ đếm thời gian chờ
            if (waitTimer >= waitTime) // Nếu đã chờ đủ 10 giây
            {
                waiting = false; // Thoát trạng thái chờ
                waitTimer = 0f; // Reset bộ đếm thời gian
                movingDown = !movingDown; // Đổi hướng di chuyển
            }
            return; // Không di chuyển khi đang chờ
        }

        // Xác định vị trí đích hiện tại
        Vector2 targetPosition = movingDown ? endPosition : startPosition;

        // Di chuyển về phía vị trí đích
        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPosition,
            verticalMoveSpeed * Time.deltaTime
        );

        // Kiểm tra xem đã đến đích chưa
        if ((Vector2)transform.position == targetPosition)
        {
            waiting = true; // Kích hoạt trạng thái chờ
        }

    }
}
