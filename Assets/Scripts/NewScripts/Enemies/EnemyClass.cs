using Pabio.Migraciones.Managers;
using UnityEngine;

namespace Pabio.Migraciones.Enemy
{
    public abstract class EnemyClass : MonoBehaviour
    {
        [Header("BaseMovement")]
        [SerializeField] public int speed;
        [SerializeField] private bool staticEnemy;
        [SerializeField] private Vector2 initialPos;

        [Header("References")]
        [SerializeField] private Animator anim;
        [SerializeField] private Rigidbody2D rb2D;
        public Transform player;
        public GameManager gameManager;


        protected virtual void Awake()
        {
            initialPos = transform.position;
            Restart();
        }

        private void OnEnable()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            gameManager = GameManager.FindAnyObjectByType<GameManager>();
            gameManager.enemiesInGame.Add(this);
        }

        public virtual void Restart()
        {
            transform.position = initialPos;
            gameManager = GameManager.FindAnyObjectByType<GameManager>();
            gameManager.enemiesInGame.Add(this);
        }

        protected virtual void BaseMovement(int speed)
        {
            if (staticEnemy) { return; }
            rb2D.linearVelocity = new Vector2(-1 * speed, 0);
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Player")) { return; }
            anim.SetBool("attack", true);
        }

        protected virtual void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision.CompareTag("Player")) { return; }
            anim.SetBool("attack", false);
        }
    }
}