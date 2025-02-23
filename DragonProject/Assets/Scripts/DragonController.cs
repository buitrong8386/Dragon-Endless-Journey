using Entity;
using UnityEditor;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    private DragonMove _dragonMove;
    private Dragon _dragon;
    private Rigidbody2D _rigidbody2D;
    private DragonFire _dragonFire;
    private Animator _animator;
    void Start()
    {
        _dragonMove = GetComponent<DragonMove>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _dragonFire = GetComponent<DragonFire>();
        _animator = GetComponent<Animator>();
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

    void Update()
    {
        HandleMovementAndJump();
        HandleFire();
    }
    private void HandleMovementAndJump()
    {
        Vector2 currentVelocity = _rigidbody2D.velocity;
        bool isMoving = false;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 moveVelocity = _dragonMove.GetMove(Direction.Left);
            currentVelocity.x = moveVelocity.x;
            _dragon.Direction = Direction.Left;
            transform.localScale = new Vector3(-1, 1, 1);
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 moveVelocity = _dragonMove.GetMove(Direction.Right);
            currentVelocity.x = moveVelocity.x;
            _dragon.Direction = Direction.Right;
            transform.localScale = new Vector3(1, 1, 1);
            isMoving = true;
        }
        else
        {
            currentVelocity.x = 0;
        }
        _animator.SetBool("Move", isMoving);
        _rigidbody2D.velocity = currentVelocity;
    }
    private void HandleFire()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _dragonFire.Fire(_dragon.Direction);
        }
    }
}
