using System;
using Entity;
using UnityEngine;

public class DragonMove : MonoBehaviour
{
    public float speed;
    public Vector2 GetMove(Direction direction)
    {
        return direction switch
        {
            Direction.Left => Vector2.left * speed * Time.deltaTime * 300f,
            Direction.Right => Vector2.right * speed * Time.deltaTime * 300f,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
