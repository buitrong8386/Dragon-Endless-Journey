using Entity;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Bullet Bullet { get; set; }

    public int MaxRange { get; set; }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        DestroyAfterRange();
    }

    private void DestroyAfterRange()
    {
        var currentPos = gameObject.transform.position;
        if (Bullet == null)
        {
            return;
        }
        var initPos = Bullet.InitialPosition;
        switch (Bullet.Direction)
        {
            case Direction.Left:
                if (initPos.x - MaxRange >= currentPos.x)
                {
                    //Destroy(gameObject);
                }

                break;
            case Direction.Right:
                if (initPos.x + MaxRange <= currentPos.x)
                {
                    //Destroy(gameObject);
                }
                break;
        }
    }
}