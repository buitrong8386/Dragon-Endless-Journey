using Entity;
using UnityEditor;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    private DragonMove _dragonMove;
    private Dragon _dragon;
    private Rigidbody2D _rigidbody2D;
    private DragonFire _dragonFire;
    void Start()
    {
        _dragonMove = GetComponent<DragonMove>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _dragonFire = GetComponent<DragonFire>();
        _dragon = new Dragon()
        {
            Name = "Default",
            Direction = Direction.Right,
            Hp = 10,
            Point = 0,
            Position = new Vector2(transform.position.x, transform.position.y),
            Guid = GUID.Generate()
        };
    }

    // Update is called once per frame
    void Update()
    {
        HandleMove();
        HandleFire();
    }
    private void HandleMove()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {

            _rigidbody2D.velocity = _dragonMove.GetMove(Direction.Left);
            _dragon.Direction = Direction.Left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {

            _rigidbody2D.velocity = _dragonMove.GetMove(Direction.Right);
            _dragon.Direction = Direction.Right;
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        }
    }
    private void HandleFire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _dragonFire.Fire();
        }
    }
}
