using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Device;

public class GroundManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> groundList;
    [SerializeField] private List<GameObject> activeGroundList;


    
    private GameObject tempObject;
    private Vector3 tempPosition;

    [SerializeField] private int distanceBetweenGrounds = 3;

    private float screenR;
    private float cameraWidth;

    public Vector3 movingVector = new Vector3(5f, 0, 0);
    //
    [SerializeField] private List<Sprite> obImage;
    [SerializeField] private GameObject ob;

    //
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
                ground.transform.position -= movingVector * Time.deltaTime;
        }
    }

    void SpawnGround()
    {
        if (groundList.Count == 0)
        {
            Debug.Log("List prefab rong");
            return;
        }
        
        if (activeGroundList.Count == 0)
        {
            tempObject = groundList[Random.Range(0, groundList.Count)];
            tempPosition = Vector3.zero;
            GameObject newGround = Instantiate(tempObject, tempPosition, Quaternion.identity);
            activeGroundList.Add(newGround);
        }
        else
        {
            GameObject lastGround = activeGroundList[activeGroundList.Count - 1];
            
            if (lastGround.transform.position.x + lastGround.GetComponent<BoxCollider2D>().size.x / 2 <= screenR)
            {
                tempObject = groundList[Random.Range(0, groundList.Count)];
                float tmpHalfPositionX = tempObject.GetComponent<BoxCollider2D>().size.x / 2; //lấy nửa kích thước theo chiều x của prefab
                
                float positionY = RandomPositionY(lastGround);
                tempPosition = new Vector3(tmpHalfPositionX + screenR + distanceBetweenGrounds ,positionY , 0);
                GameObject newGround = Instantiate(tempObject, tempPosition, Quaternion.identity);
                activeGroundList.Add(newGround);
                //
                int random = Random.Range(0, 4);
                for (int i = 0; i < random; i++)
                {
                    Instantiate(ob, new Vector3(tmpHalfPositionX + screenR + distanceBetweenGrounds + Random.Range(-tmpHalfPositionX, tmpHalfPositionX), positionY - 2.5f), Quaternion.identity);
                }                
            }
        }

    }

    float RandomPositionY(GameObject gameObject)
    {
        float randomY;
        do       
            randomY = Random.Range(0f, 5.0f);   
        while (Mathf.Abs(randomY - gameObject.transform.position.y) > 4);

        return randomY;
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
