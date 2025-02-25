using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    //[SerializeField] private GameObject[] arrayGround;
    private float groundR;
    private float screenR;
    private float cameraWidth;
    private bool hasGeneratedGround = false;
    [SerializeField] private int distanceBetweenGrounds = 3;
    public GroundManager script;

    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        cameraWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect; //tính chiều dài camera
        screenR = cameraWidth / 2; //tọa độ x biên phải của camera
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (groundR <= -screenR + 2f) //tọa độ x biên trái của camera, nếu nhỏ hơn xóa obj
            Destroy(this.gameObject);
        this.transform.position -= new Vector3(5f, 0, 0) * Time.deltaTime;

        groundR = this.transform.position.x + groundCollider.size.x / 2;
        if (groundR <= screenR && !hasGeneratedGround) // tọa độ x biên phải của camera, nếu nhỏ hơn tạo obj
        {      
            GenerateGround();
            hasGeneratedGround = true;
        }
    }

    void GenerateGround()
    {
        Vector3 spammer;
        spammer.x = screenR + groundCollider.size.x / 2 + distanceBetweenGrounds;
        Debug.Log(groundCollider.size.x / 2);
        spammer.y = this.transform.position.y + Random.Range(-3, 3);
        spammer.z = this.transform.position.z;
        Instantiate(groundCollider, spammer, Quaternion.identity);// clone obj
    }
}
