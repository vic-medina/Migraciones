using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundSwitch : MonoBehaviour
{
    [Header("Fade Zone Panel")] //Sprite que cubre toda la pantalla para hacer el efecto de fade
    [SerializeField] private TextMeshProUGUI nombreZonaText;
    [SerializeField] private Image fadeMask;
    [SerializeField] private float fadeInDuration = 1f;
    [SerializeField] private float fadeOutDuration = 1f;

    [Header("Fondos Parallax (galería)")] //Lista de fondos parallax que se van a ir alternando
    [SerializeField] private List<GameObject> fondos = new List<GameObject>();
    
    [Header("Duración FadeBackground")] //Duración del fade in y fade out
    [SerializeField] private float duracionFadeIn = 1f;
    [SerializeField] private float duracionFadeOut = 1f;

    [Header("PlayerDot")]
    [SerializeField] private RectTransform playerDot; // Punto que representa al jugador en el minimapa
    [SerializeField] private Vector2 newPosition;

    public IEnumerator FadeFondos(int nuevoFondoIndex, string nuevaZona) // Coroutine para hacer el fade entre fondos
    {
        nombreZonaText.text = nuevaZona;

        if (nuevoFondoIndex < 0 || nuevoFondoIndex >= fondos.Count) // Validación del índice
        {
            Debug.LogWarning("Índice de fondo inválido");
            yield break;
        }

        Color baseColor = fadeMask.color;

        // FadeIn
        float tiempo = 0f;
        while (tiempo < duracionFadeIn)
        {
            tiempo += Time.deltaTime;
            float alpha = tiempo / duracionFadeIn; // 0 -> 1
            fadeMask.color = new Color(baseColor.r, baseColor.g, baseColor.b, alpha);
            yield return null;
        }

        // Deshabilitar todos los fondos y habilitar el nuevo
        for (int i = 0; i < fondos.Count; i++)
        {
            fondos[i].SetActive(i == nuevoFondoIndex);
        }
        
        // FadeOut
        tiempo = 0f;
        while (tiempo < duracionFadeOut)
        {
            tiempo += Time.deltaTime;
            float alpha = 1f - (tiempo / duracionFadeOut); // 1 -> 0
            fadeMask.color = new Color(baseColor.r, baseColor.g, baseColor.b, alpha);
            yield return null;
        }
    }

    public void FadeNamePanel(CanvasGroup panelZone) // Coroutine para hacer el fade del nombre de la zona
    {
        panelZone.DOFade(1,fadeInDuration).OnComplete(() => panelZone.DOFade(0,fadeOutDuration));
    }

    public void UpdatePlayerDot(Vector2 newDotPosition, float moveTime)
    {
        playerDot.DOAnchorPos(newDotPosition, moveTime);
    }
}