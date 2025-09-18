using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform playerTf;

    [Header("Movimiento")]
    [SerializeField] private float moveSpeed;   // velocidad de ataque
    [SerializeField] private float baseSpeed;  // velocidad normal del runner (hacia la izquierda)

    private Vector2 attackDirection;
    private bool isAttacking = false;

    private void Start()
    {
        playerTf = GameObject.FindGameObjectWithTag("Player").transform;
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



