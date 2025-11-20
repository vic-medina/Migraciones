using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Animator anim;
    [SerializeField] public Rigidbody2D rb2D;

    [Header("Movimiento")]
    [SerializeField] public int speed;

    protected virtual void Move(int speed)
    {
        rb2D.linearVelocity = new Vector2(-1 * speed, 0);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("attack", true);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("attack", false);
        }
    }
}