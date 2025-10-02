using UnityEngine;

public class SnakeAttack : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform playerTf;

    [Header("Movimiento")]
    [SerializeField] private float moveSpeed;   // velocidad de ataque
    [SerializeField] private Vector2 attackDirection;
    public bool isAttacking = false;

    private void Start()
    {
        playerTf = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnEnable()
    {
        isAttacking = false;
        rb.linearVelocity = Vector2.zero; // Reiniciar la velocidad al activar
    }

    void FixedUpdate()
    {
        if (isAttacking)
        {
            rb.linearVelocity = attackDirection * moveSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isAttacking)
        {
            // Guardar dirección hacia el jugador solo en ese momento
            attackDirection = (playerTf.position - transform.position).normalized;
            isAttacking = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 6f);
    }
}