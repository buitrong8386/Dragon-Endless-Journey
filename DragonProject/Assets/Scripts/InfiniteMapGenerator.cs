using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteMapGenerator : MonoBehaviour
{
    public GameObject[] groundPrefabs; // Mảng các prefab mặt đất khác nhau
    public GameObject[] obstaclePrefabs; // Mảng các prefab chướng ngại vật
    public float segmentWidth = 20f; // Độ rộng của mỗi đoạn map
    public int initialSegments = 5; // Số đoạn map khởi tạo ban đầu
    public int keepSegments = 7; // Số đoạn map giữ lại trong bộ nhớ

    public float obstacleSpawnChance = 0.5f; // Tỷ lệ xuất hiện chướng ngại vật
    public float minObstacleSpacing = 3f; // Khoảng cách tối thiểu giữa các chướng ngại vật

    private Transform playerTransform; // Transform của player
    private List<GameObject> activeSegments = new(); // Danh sách các đoạn map đang active
    private float lastSpawnX = 0f; // Vị trí X của đoạn map cuối cùng
    private float despawnX = 0f; // Vị trí X để despawn map
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Tạo map ban đầu
        for (int i = 0; i < initialSegments; i++)
        {
            SpawnNewSegment();
        }
    }

    void Update()
    {
        // Kiểm tra vị trí của player để tạo thêm map
        if (playerTransform.position.x > lastSpawnX - (segmentWidth * 2))
        {
            SpawnNewSegment();
        }

        // Xóa các đoạn map cũ
        CleanupOldSegments();
    }

    void SpawnNewSegment()
    {
        // Chọn ngẫu nhiên một prefab mặt đất
        GameObject groundPrefab = groundPrefabs[Random.Range(0, groundPrefabs.Length)];

        // Tạo đoạn map mới
        GameObject newSegment = Instantiate(groundPrefab,
            new Vector3(lastSpawnX + segmentWidth / 2, 0, 0),
            Quaternion.identity);

        // Thêm chướng ngại vật
        SpawnObstacles(newSegment);

        // Cập nhật vị trí spawn tiếp theo
        lastSpawnX += segmentWidth;

        // Thêm vào danh sách active
        activeSegments.Add(newSegment);
    }

    void SpawnObstacles(GameObject segment)
    {
        float segmentStartX = segment.transform.position.x - segmentWidth / 2;
        float lastObstacleX = segmentStartX;

        // Duyệt qua chiều dài của đoạn map
        while (lastObstacleX < segmentStartX + segmentWidth)
        {
            // Kiểm tra xem có spawn obstacle không
            if (Random.value < obstacleSpawnChance)
            {
                // Chọn ngẫu nhiên một obstacle
                GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

                // Tính toán vị trí spawn
                float spawnX = lastObstacleX + minObstacleSpacing;
                float spawnY = segment.transform.position.y + 1f; // Đặt obstacle trên mặt đất

                // Tạo obstacle
                Instantiate(obstaclePrefab,
                    new Vector3(spawnX, spawnY, 0),
                    Quaternion.identity,
                    segment.transform);

                lastObstacleX = spawnX;
            }

            lastObstacleX += minObstacleSpacing;
        }
    }

    void CleanupOldSegments()
    {
        // Xác định vị trí để xóa map
        despawnX = playerTransform.position.x - (segmentWidth * keepSegments / 2);

        // Xóa các đoạn map quá xa về bên trái
        for (int i = activeSegments.Count - 1; i >= 0; i--)
        {
            if (activeSegments[i].transform.position.x < despawnX)
            {
                Destroy(activeSegments[i]);
                activeSegments.RemoveAt(i);
            }
        }
    }
}

