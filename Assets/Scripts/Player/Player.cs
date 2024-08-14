using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        protected State playerState;
        protected Rigidbody2D rb;
        public virtual void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }
}
