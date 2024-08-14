using UnityEngine;

namespace Assets.Scripts.Entities.Player
{
    public class Player : MonoBehaviour
    {
        protected Rigidbody2D rb;
        public virtual void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }
}
