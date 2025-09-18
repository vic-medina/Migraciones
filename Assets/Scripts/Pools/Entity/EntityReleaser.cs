using UnityEngine;

public class EntityReleaser : MonoBehaviour
{
    [SerializeField] private EntityPool foodPool;
    [SerializeField] private EntityPool enemyPool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            foodPool.ReturnToPool(collision.gameObject);
        }
        else if (collision.CompareTag("Enemigo"))
        {
            enemyPool.ReturnToPool(collision.gameObject);
        }
    }
}
