using Contants;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GroundManager groundManager;
    void Start()
    {
        groundManager = GameObject.Find(TagContants.GROUND_MANAGER).GetComponent<GroundManager>();
    }

    void Update()
    {
        MoveGround();
        RemoveOffScreenGround();
    }

    void MoveGround()
    {    
        transform.transform.position -= groundManager.movingVector * Time.deltaTime;
        
    }

    void RemoveOffScreenGround()
    {
        
        if (transform.position.x <= -(Camera.main.orthographicSize * 2 * Camera.main.aspect)/2 - 2f)
        {
            Destroy(gameObject);
        }
    }
}
