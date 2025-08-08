using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private EnergyBar energyBar;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float energyCost = .5f;
    [SerializeField] private float foodValue = 1f;
    [SerializeField] private float enemyDamage = 1f;
    [SerializeField] public bool canJump;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.linearVelocity = new Vector2(0, jumpForce);
            energyBar.UseEnergy(energyCost);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            energyBar.slider.value += foodValue;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Enemy"))
        {
            energyBar.slider.value -= enemyDamage;
            Destroy(collision.gameObject);
        }
    }
}