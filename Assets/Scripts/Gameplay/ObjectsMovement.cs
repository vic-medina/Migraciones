using UnityEngine;

public class ObjectsMovement : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Rigidbody2D rb2D;

    [Header("Velocidad")]
    [SerializeField] public float speed = 5f;

    private void Update() //Mover el objeto a la izquierda constantemente
    {
        rb2D.linearVelocity = new Vector2(-1 * speed, 0);    
    } 
}
