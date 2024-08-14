using System;

using UnityEngine;

namespace Assets.Scripts.Player
{
    public class HorizontalMovement : Player
    {
        private SpriteRenderer sp;
     
        [SerializeField] private float _speed;
        [field: SerializeField] public bool IsMove { get; private set; }
        public override void Start()
        {
            base.Start();
            sp = GetComponent<SpriteRenderer>();
        }
        public void Move()
        {
            float x = Input.GetAxisRaw("Horizontal") * _speed * Time.fixedDeltaTime;
            rb.velocity = new Vector2(x, rb.velocityY);

            if (x != 0)
                IsMove = true;
            else
                IsMove = false;

            FlipX(x);
            
        }
        public void FlipX(float x)
        {
            if (x > 0)
                sp.flipX = false;
            else if (x < 0)
                sp.flipX = true;
        }
    }
}
