using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class Ob : MonoBehaviour
{
    [SerializeField] private GroundManager groundManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        groundManagerScript = GameObject.Find("GroundManager").GetComponent<GroundManager>();
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
