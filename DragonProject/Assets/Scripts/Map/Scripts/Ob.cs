using Contants;
using UnityEngine;


public class Ob : MonoBehaviour
{
    [SerializeField] private GroundManager groundManagerScript;

    void Start()
    {
        groundManagerScript = GameObject.Find(TagContants.GROUND_MANAGER).GetComponent<GroundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveGround();
        RemoveOffScreenGround();
    }

    void MoveGround()
    {    
        transform.transform.position -= groundManagerScript.movingVector * Time.deltaTime;
        
    }

    void RemoveOffScreenGround()
    {
        
        if (transform.position.x <= -(Camera.main.orthographicSize * 2 * Camera.main.aspect)/2 - 2f)
        {
            Destroy(gameObject);
        }
    }
}
