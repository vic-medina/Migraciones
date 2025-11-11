using DG.Tweening;
using UnityEngine;

public class WagonMov : MonoBehaviour
{
    [SerializeField] private float finalPosition;
    [SerializeField] private float time;
    [SerializeField] private bool mov;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && mov)
        {
            transform.DOMoveX(finalPosition, time);
            mov = false;
        }
    }
}
