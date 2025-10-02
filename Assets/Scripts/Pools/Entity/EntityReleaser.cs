using UnityEngine;

public class EntityReleaser : MonoBehaviour
{
    [SerializeField] private EntityPool owlPool;
    [SerializeField] private EntityPool snakePool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Owl"))
        {
            owlPool.ReturnToPool(collision.gameObject);
        }
        else if (collision.CompareTag("Snake"))
        {
            snakePool.ReturnToPool(collision.gameObject);
        }
    }
}
