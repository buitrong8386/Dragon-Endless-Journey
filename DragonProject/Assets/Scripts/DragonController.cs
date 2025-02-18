using System;
using DefaultNamespace;
using Entity;
using UnityEditor;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    private Dragon _dragon;
    private CameraController _cameraController;
    public new GameObject camera;
    private Rigidbody2D _rigidbody2D;
    public Transform currentGunBarrel;
    private DragonMove _dragonMove;
    private void Start()
    {
        _dragon = new Dragon
        {
            Name = "Default",
            Direction = Direction.Right,
            Hp = 10,
            Point = 0,
            Position = new Vector2(transform.position.x, transform.position.y),
            Guid = GUID.Generate()
        };
        gameObject.transform.position = _dragon.Position;
        _dragonMove = gameObject.GetComponent<DragonMove>();
        _cameraController = camera.GetComponent<CameraController>();
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Move(Direction.Left);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Move(Direction.Right);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //Move(Direction.Up);
        }
        else _rigidbody2D.velocity = Vector2.zero;
        if (Input.GetKey(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Move(Direction direction)
    {
        _dragon.Position = _dragonMove.Move(direction);
        _rigidbody2D.velocity = _dragon.Position * 2 * Time.deltaTime * 400f;
        // if (_tank.Position != Vector2.zero)
        // {
        //     _animator.SetFloat("x", _tank.Position.x);
        //     _animator.SetFloat("y", _tank.Position.y);
        // }
        _dragon.Direction = direction;
    }
    private void Fire()
    {
        var b = new Bullet
        {
            Direction = _dragon.Direction,
            Tank = _dragon,
            InitialPosition = new Vector2(currentGunBarrel.position.x, currentGunBarrel.position.y)
        };
        GetComponent<DragonFirer>().Fire(b);
    }
}