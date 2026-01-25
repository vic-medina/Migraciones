using DG.Tweening;
using UnityEngine;

public class MovibleObjects : MonoBehaviour
{
    [SerializeField] private float finalPosition;
    [SerializeField] private float time;
    [SerializeField] private bool canMove;

    private Vector3 initialPos;

    private void Awake()
    {
        initialPos = transform.position;
    }

    public void Restart()
    {
        transform.position = initialPos;
        canMove = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canMove)
        {
            transform.DOMoveX(finalPosition, time);
            canMove = false;
        }
    }
}
