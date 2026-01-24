using Pabio.Migraciones.Managers;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameManager.GameComplete();
    }
}