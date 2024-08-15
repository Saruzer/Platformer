using UnityEngine;

namespace Assets.Scripts.Entities.Player
{
    public class HorizontalMovement : Entity, IMove
    {

        [SerializeField] private float _speed;
        [field: SerializeField] public bool IsMove { get; private set; }

        private float x;
        private void FixedUpdate()
        {
            Move();
        }
        public void Move()
        {
            x = Input.GetAxisRaw("Horizontal") * _speed * Time.fixedDeltaTime;
            rb.velocity = new Vector2(x, rb.velocityY);
            IsMove = x != 0;
        }

        public int GetMoveDirection()
        {
            return Mathf.RoundToInt(x);
        }
    }
}
