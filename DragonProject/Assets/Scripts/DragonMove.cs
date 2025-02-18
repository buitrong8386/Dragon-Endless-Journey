using System;
using Entity;
using UnityEngine;

public class DragonMove : MonoBehaviour
{
    public Vector2 Move(Direction direction)
    {
        Debug.Log(direction);
        return direction switch
        {
            Direction.Left => Vector2.left,
            Direction.Right => Vector2.right,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
