using UnityEngine;

namespace Assets.Scripts.Player.Animation
{
    public class Animation : MonoBehaviour
    {
        Animator anim;
        public void OnEnable()
        {
            PlayerMovement.OnMove += ChangeAnimation;
        }
        public void OnDisable()
        {
            PlayerMovement.OnMove -= ChangeAnimation;
        }
        public void Start()
        {
            anim = GetComponent<Animator>();
        }
        public void ChangeAnimation(State animation)
        {
            anim.SetInteger("State", (int)animation);
        }
    }
}
