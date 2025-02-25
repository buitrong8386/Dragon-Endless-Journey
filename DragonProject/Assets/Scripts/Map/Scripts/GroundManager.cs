using System.Collections.Generic;
using UnityEngine;


public class GroundManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> groundList;
    [SerializeField] private List<GameObject> activeGroundList;
    public float v = 10f;
    private GameObject tempObject;
    private Vector3 tempPosition;

    [SerializeField] private int distanceBetweenGrounds = 3;

    private float screenR;
    private float cameraWidth;

    void Awake()
    {
        cameraWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect; //tính chiều dài camera
        screenR = cameraWidth / 2;
    }
    void Start()
    {
        SpawnGround();
    }

    void FixedUpdate()
    {
        MoveGround();
        SpawnGround();
        RemoveOffScreenGround();
    }

    void MoveGround()
    {
        foreach (GameObject ground in activeGroundList)
        {
            if( ground != null)
                ground.transform.position -= new Vector3(5f, 0, 0) * Time.deltaTime;
        }
    }
    void SpawnGround()
    {
        if (groundList.Count == 0)
        {
            return;
        }
        
        if (activeGroundList.Count == 0)
        {
        tempObject = groundList[Random.Range(0, groundList.Count)];
            tempPosition = Vector3.zero;
        GameObject newGrid = Instantiate(tempObject, tempPosition, Quaternion.identity);
        activeGroundList.Add(newGrid);
        }
        else
        {
            GameObject lastGround = activeGroundList[activeGroundList.Count - 1];
            
            if (lastGround.transform.position.x + lastGround.GetComponent<BoxCollider2D>().size.x / 2 <= screenR)
            {
                tempObject = groundList[Random.Range(0, groundList.Count)];
                tempPosition = new Vector3(tempObject.GetComponent<BoxCollider2D>().size.x / 2 + screenR + distanceBetweenGrounds, Random.Range(-3, 3), 0);
                GameObject newGrid = Instantiate(tempObject, tempPosition, Quaternion.identity);
                activeGroundList.Add(newGrid);
            }
        }

    }

    void RemoveOffScreenGround()
    {
        GameObject firstGround = activeGroundList[0];
        if (firstGround.transform.position.x + firstGround.GetComponent<BoxCollider2D>().size.x / 2 <= -screenR - 2f)
        {
            Destroy(firstGround);
            activeGroundList.Remove(firstGround);
        }
    }
}
