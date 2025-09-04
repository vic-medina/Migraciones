using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSwitch : MonoBehaviour
{
    [Header("Fade Sprite (capa superpuesta)")]
    [SerializeField] private SpriteRenderer fadeMask;

    [Header("Fondos Parallax (galería)")]
    [SerializeField] private List<GameObject> fondos = new List<GameObject>();
    
    [Header("Duración Fade")]
    [SerializeField] private float duracionFadeIn = 1f;
    [SerializeField] private float duracionFadeOut = 1f;

    private void Start()
    {
        // Aseguramos que solo un fondo esté activo al inicio (el primero)
        for (int i = 0; i < fondos.Count; i++)
        {
            fondos[i].SetActive(i == 0);
        }
    }

    public IEnumerator FadeFondos(int nuevoFondoIndex)
    {
        if (nuevoFondoIndex < 0 || nuevoFondoIndex >= fondos.Count)
        {
            Debug.LogWarning("Índice de fondo inválido");
            yield break;
        }

        Color baseColor = fadeMask.color;

        // --- Paso 1: Fade IN (transparente -> negro) ---
        float tiempo = 0f;
        while (tiempo < duracionFadeIn)
        {
            tiempo += Time.deltaTime;
            float alpha = tiempo / duracionFadeIn; // 0 -> 1
            fadeMask.color = new Color(baseColor.r, baseColor.g, baseColor.b, alpha);
            yield return null;
        }

        // --- Paso 2: Apagar todos los fondos y encender el nuevo ---
        for (int i = 0; i < fondos.Count; i++)
        {
            fondos[i].SetActive(i == nuevoFondoIndex);
        }

        // --- Paso 3: Fade OUT (negro -> transparente) ---
        tiempo = 0f;
        while (tiempo < duracionFadeOut)
        {
            tiempo += Time.deltaTime;
            float alpha = 1f - (tiempo / duracionFadeOut); // 1 -> 0
            fadeMask.color = new Color(baseColor.r, baseColor.g, baseColor.b, alpha);
            yield return null;
        }
    }
}