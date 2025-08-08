using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody2D rb2D;

    private void Update()
    {
        rb2D.linearVelocity = new Vector2(-1 * speed, 0);    
    }
}
