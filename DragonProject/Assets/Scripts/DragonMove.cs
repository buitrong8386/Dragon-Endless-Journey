using System;
using Entity;
using UnityEngine;

public class DragonMove : MonoBehaviour
{
    public float _speed;
    private bool _isJumping = false;
    public Vector2 GetMove(Direction direction)
    {
        return direction switch
        {
            Direction.Left => Vector2.left * _speed * Time.deltaTime * 300f,
            Direction.Right => Vector2.right * _speed * Time.deltaTime * 300f,
            Direction.Jump => Jump(GetComponent<Rigidbody2D>(), 5f),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    private Vector2 Jump(Rigidbody2D rigidbody, float jumpForce)
    {
        if (!_isJumping)
        {
            rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            _isJumping = true;
        }
        return rigidbody.velocity;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BackGround"))
        {
            _isJumping = false;
        }
    }
}
