using System;
using Entity;
using UnityEngine;

namespace DefaultNamespace
{
    public class DragonFirer : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Sprite spriteRight;
        public Sprite spriteLeft;
        public Sprite spriteUp;
        public Sprite spriteDown;
        public int speed;
        public int maxRange;
        public float delay;
        public float lastFire = 0f;

        private void Start()
        {
        }

        private void Update()
        {
        }

        public void Fire(Bullet b)
        {
            if (lastFire + delay > Time.time)
            {
                return;
            }
            var bullet = Instantiate(bulletPrefab, b.InitialPosition, Quaternion.identity); // tạo đạn
            var sr = bullet.GetComponent<SpriteRenderer>(); // lấy sprite renderer của đạn
            var rigidBody2d = bullet.GetComponent<Rigidbody2D>(); // lấy rigidbody2d của đạn
            var bulletController = bullet.GetComponent<BulletController>(); // lấy script BulletController của đạn
            bulletController.Bullet = b;
            bulletController.MaxRange = maxRange;
            Vector2 force;
            switch (b.Direction)
            {
                case Direction.Right:
                    sr.sprite = spriteRight;
                    force = new Vector2(speed, 0);
                    break;
                case Direction.Left:
                    sr.sprite = spriteLeft;
                    force = new Vector2(-1 * speed, 0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            rigidBody2d.AddForce(force, ForceMode2D.Impulse);// ta động lực cho đạn
            lastFire = Time.time;
        }
    }
}