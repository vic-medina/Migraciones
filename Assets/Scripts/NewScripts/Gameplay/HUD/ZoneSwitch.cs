using Pabio.Migraciones.Displays;
using Pabio.Migraciones.Managers;
using System;
using UnityEngine;

public class ZoneSwitch : MonoBehaviour
{
    public GameManager gameManager;
    public int locationIndex;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.ChangeZone(locationIndex);
        }
    }
}