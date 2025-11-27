using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCollision : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private PlayerUIController playerUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FinishLine"))
        {
            //Time.timeScale = 0f;
            finishPanel.SetActive(true);
            playerUI.GotoFinalPanel();
        }
    }
}