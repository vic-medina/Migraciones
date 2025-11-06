using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundSwitch : MonoBehaviour
{
    [Header("Fade Sprite (capa superpuesta)")] //Sprite que cubre toda la pantalla para hacer el efecto de fade
    [SerializeField] private Image fadeMask;

    [Header("Fondos Parallax (galería)")] //Lista de fondos parallax que se van a ir alternando
    [SerializeField] private List<GameObject> fondos = new List<GameObject>();
    
    [Header("Duración Fade")] //Duración del fade in y fade out
    [SerializeField] private float duracionFadeIn = 1f;
    [SerializeField] private float duracionFadeOut = 1f;

    private void Start()
    {
    }

    public IEnumerator FadeFondos(int nuevoFondoIndex) // Coroutine para hacer el fade entre fondos
    {
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
}