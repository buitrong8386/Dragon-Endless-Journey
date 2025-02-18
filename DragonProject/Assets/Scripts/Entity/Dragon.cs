using UnityEditor;
using UnityEngine;

namespace Entity
{
    public class Dragon
    {
        public Direction Direction { get; set; }
        public string Name { get; set; }
        public int Point { get; set; }
        public int Hp { get; set; }
        public GUID Guid { get; set; }
        public Vector2 Position { get; set; }

        public void Move(float x, float y)
        {
            Position = new Vector2(x, y);
        }
    }
}