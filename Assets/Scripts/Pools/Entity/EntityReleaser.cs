using UnityEngine;

public class EntityReleaser : MonoBehaviour
{
    [SerializeField] private EntityPool enemyPool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Trigger entered by: {collision.name}, Tag: {collision.tag}");

        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Returning to pool...");
            //SnakeAttack attackController = collision.gameObject.GetComponent<SnakeAttack>();
            //attackController.isAttacking = false; // Reset the attacking state
            enemyPool.ReturnToPool(collision.gameObject);
        }
    }

}
