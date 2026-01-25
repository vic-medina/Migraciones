using DG.Tweening;
using Pabio.Migraciones.Managers;
using System.Collections;
using UnityEngine;

namespace Pabio.Migraciones.PlayerEssentials
{
    public class PlayerMovement : MonoBehaviour
    {

        [Header("Movement")]
        [SerializeField] private float forwardSpeed = 3f;
        [SerializeField] private float flapForce = 6f;
        [SerializeField] private bool canMove;

        [Header("Knockback")]
        [SerializeField] private float knockbackDuration;
        [SerializeField] private float freezeDuration;
        [SerializeField] private Vector2 knockbackOffsetUp = new(-1f, 2f);
        [SerializeField] private Vector2 knockbackOffsetDown = new(-1f, -2f);
        private bool isFrozen;

        [Header("References")]
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private PlayerAnimator playerAnim;
        public GameManager gameManager;

        private Tween knockbackTween;

        private void FixedUpdate()
        {
            if (isFrozen || !canMove) return;

            rb.linearVelocity = new Vector2(forwardSpeed, rb.linearVelocity.y);
        }

        private void Update()
        {
            if (isFrozen || !canMove) return;

            if (Input.GetKey(KeyCode.Space))
                Flap();

            if (Input.GetKeyUp(KeyCode.Space))
                playerAnim.BoolAnimation("flap", false);
        }

        private void Flap()
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * flapForce, ForceMode2D.Impulse);
            playerAnim.BoolAnimation("flap", true);
        }

        public void ApplyKnockback(float collisionY)
        {
            if (isFrozen) return;

            StartCoroutine(KnockbackRoutine(collisionY));
        }

        public void StopMovement()
        {
            forwardSpeed = 0f;
            flapForce = 0f;
            canMove = false;
        }

        public void AllowMovement()
        {
            forwardSpeed = 4f;
            flapForce = 6f;
            canMove = true;
        }

        private IEnumerator KnockbackRoutine(float collisionY)
        {
            Vector2 offset = collisionY > transform.position.y
                ? knockbackOffsetDown
                : knockbackOffsetUp;

            knockbackTween?.Kill();

            knockbackTween = transform
                .DOMove((Vector2)transform.position + offset, knockbackDuration)
                .SetEase(Ease.OutQuad);

            FreezePlayer();
            gameManager.backgroundController.FreezeBackground();
            yield return new WaitForSeconds(freezeDuration);
            UnfreezePlayer();
            gameManager.backgroundController.UnfreezeBackground();
        }

        public void FreezePlayer()
        {
            isFrozen = true;
            rb.linearVelocity = Vector2.zero;
            rb.constraints |= RigidbodyConstraints2D.FreezePositionY;
        }

        public void UnfreezePlayer()
        {
            isFrozen = false;
            rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(CompareTag("Limite"))
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f,0f);
            }
        }

        public void Restart()
        {
            forwardSpeed = 4f;
            flapForce = 6f;
            FreezePlayer();
            canMove = true;
            knockbackTween?.Kill();
            rb.linearVelocity = Vector2.zero;
            transform.position = Vector2.zero;
        }
    }
}