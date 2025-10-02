using UnityEngine;
using System.Collections;

public class OwlAttack : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Movimiento")]
    [SerializeField] private float horizontalSpeed;   // velocidad horizontal
    [SerializeField] private float verticalSpeed;     // velocidad vertical
    [SerializeField] private float directionChangeInterval; // cada cuánto cambia dirección Y
    [SerializeField] private float randomY;

    private void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        StartCoroutine(UpdateVerticalDirection());
    }

    private IEnumerator UpdateVerticalDirection()
    {
        while (true)
        {
            randomY = Random.Range(-1f, 1f); // dirección vertical aleatoria
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = new Vector2(-horizontalSpeed, randomY * verticalSpeed);
        rb.linearVelocity = velocity;
    }
}
