using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class FlipSpriteX : MonoBehaviour
    {
        [Tooltip("Used for indicate where the sprite is looking. If true, it means the sprite facing left. Contrary if false")]
        [field: SerializeField] private bool IsLeftViewSprite;
        private SpriteRenderer sp;
        private IMove move;
        private void Start()
        { 
            sp = GetComponent<SpriteRenderer>();
            move = GetComponent<IMove>();
        }
        private void Update() => FlipX();
        public void FlipX()
        {
            if (move.GetMoveDirection() > 0)
                sp.flipX = IsLeftViewSprite == true ? true : false;
            else if (move.GetMoveDirection() < 0)
                sp.flipX = IsLeftViewSprite == true ? false: true;
        }
    }
}
