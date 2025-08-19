using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private EntityPool foodPool;
    [SerializeField] private EntityPool enemyPool;
    [SerializeField] private EnergyBar energyBar;
    [SerializeField] private float foodValue;
    [SerializeField] private float enemyDamage;

    private void Start()
    {
        Time.timeScale = 1;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            energyBar.slider.value += foodValue;
            foodPool.ReturnToPool(collision.gameObject);
        }
        else if (collision.CompareTag("Enemy"))
        {
            energyBar.slider.value -= enemyDamage;
            enemyPool.ReturnToPool(collision.gameObject);
        }
    }
}