using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WinCollision : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private PlayerUIController playerUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Time.timeScale = 0f;
            winPanel.SetActive(true);
            playerUI.GotoFinalPanel();
        }
    }
}