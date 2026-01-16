using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Pabio.Migraciones
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Rigidbody2D rb;

        [Header("Movement")]
        [SerializeField] private float forwardSpeed = 3f;
        [SerializeField] private float flapForce = 6f;

        [Header("Knockback")]
        [SerializeField] private float knockbackDuration = 0.2f;
        [SerializeField] private float freezeDuration = 0.1f;
        [SerializeField] private Vector2 knockbackOffsetUp = new(-1f, 2f);
        [SerializeField] private Vector2 knockbackOffsetDown = new(-1f, -2f);


        private Tween knockbackTween;
        private bool isFrozen;
        private bool canMove;

        private void FixedUpdate()
        {
            if (isFrozen || !canMove) return;

            rb.linearVelocity = new Vector2(forwardSpeed, rb.linearVelocity.y);
        }

        private void Update()
        {
            if (isFrozen || !canMove) return;

            if (Input.GetKeyDown(KeyCode.Space))
                Flap();
        }

        private void Flap()
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * flapForce, ForceMode2D.Impulse);
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
            yield return new WaitForSeconds(freezeDuration);
            UnfreezePlayer();
        }

        private void FreezePlayer()
        {
            isFrozen = true;
            rb.linearVelocity = Vector2.zero;
            rb.constraints |= RigidbodyConstraints2D.FreezePositionY;
        }

        private void UnfreezePlayer()
        {
            isFrozen = false;
            rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        }

        public void Restart()
        {
            forwardSpeed = 3f;
            flapForce = 6f;
            isFrozen = false;
            canMove = true;
            knockbackTween?.Kill();
            rb.linearVelocity = Vector2.zero;
            transform.position = Vector2.zero;
        }
    }
}