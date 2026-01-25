using Pabio.Migraciones.Managers;
using System.Collections;
using UnityEngine;

namespace Pabio.Migraciones.PlayerEssentials
{
    public abstract class PlayerClass : MonoBehaviour, IPlayable
    {
        [Header("PlayerInfo")]
        public string speciesName;
        [SerializeField] private int currentHealth;

        [Header("References")]
        public GameManager gameManager;
        public PlayerMovement playerMovement;
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private PlayerAnimator playerAnim;

        protected virtual void Awake()
        {
            Restart();
        }

        public virtual void Restart()
        {
            playerMovement?.Restart();
            playerHealth?.Restart();
            SetCurrentHealth();
        }

        public virtual void OnTakeDamage(int damage, float collision)
        {
            if (!playerHealth.canTakeDamage) { return; }
            if (damage <= 0 || currentHealth <= 0) return;

            playerHealth?.ReduceHealth(damage);
            SetCurrentHealth();

            if (currentHealth == 0)
            {
                Die();
                return;
            }

            playerAnim?.TriggerAnimation("damaged");
            playerMovement?.ApplyKnockback(collision);
            //gameManager.backgroundController.FreezeBackground();
        }

        public virtual void Heal(int amount)
        {
            if (amount <= 0 || currentHealth <= 0) return;

            playerHealth.IncreaseHealth(amount);
            SetCurrentHealth();
            playerAnim?.TriggerAnimation("heal");
        }

        public void Die()
        {
            playerMovement?.StopMovement();
            playerAnim?.TriggerAnimation("lose");
            gameManager.GameOver();
        }

        public virtual void OnTriggerEnter2D(Collider2D collision)
        {
            switch (collision.gameObject.tag)
            {
                case "Food":
                    Heal(1);
                    collision.gameObject.SetActive(false);
                    break;
                case "Object":
                    if (!playerHealth.canTakeDamage) { return; }
                    var collisionY = collision.transform.position.y;
                    OnTakeDamage(1, collisionY);
                    break;
            }
        }

        private void SetCurrentHealth()
        {
            currentHealth = playerHealth.currentHealth;
        }
    }
}