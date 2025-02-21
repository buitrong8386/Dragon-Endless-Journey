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
        HandleMove();
        HandleFire();
    }
    private void HandleMove()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {

            _rigidbody2D.velocity = _dragonMove.GetMove(Direction.Left);
            _dragon.Direction = Direction.Left;
            transform.localScale = new Vector3(-1, 1, 1);
            _animator.SetBool("Move", true);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {

            _rigidbody2D.velocity = _dragonMove.GetMove(Direction.Right);
            _dragon.Direction = Direction.Right;
            transform.localScale = new Vector3(1, 1, 1);
            _animator.SetBool("Move", true);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _rigidbody2D.velocity = _dragonMove.GetMove(Direction.Jump);
            _dragon.Direction = Direction.Jump; 
            _animator.SetBool("Move", false);
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
            _animator.SetBool("Move", false);
        }
    }
    private void HandleFire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _dragonFire.Fire(_dragon.Direction);
        }
    }
}
