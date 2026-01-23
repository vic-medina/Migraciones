using UnityEngine;

namespace Pabio.Migraciones.PlayerEssentials
{
    public class PlayerAnimator : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Animator animator;

        public void TriggerAnimation(string animationName)
        {
            animator.SetTrigger(animationName);
        }

        public void BoolAnimation(string animationName, bool boolean)
        {
            animator.SetBool(animationName, boolean);
        }
    }
}
