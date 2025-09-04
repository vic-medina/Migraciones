using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSelector : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Slider loadbar;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] public Button playButton;

    [Header("Especie/Nivel Seleccionado")]
    [SerializeField] private int specieSelected;

    private void Start() // Inicializa el botón de jugar como no interactivo
    {
        playButton.interactable = false;
    }

    public void SelectSpecie(string specie) // Asigna el nivel basado en la especie seleccionada
    {
        switch (specie)
        {
            case "Bat":
                specieSelected = 1;
                break;
            case "DragonFly":
                specieSelected = 2;
                break;
            case "Butterfly":
                specieSelected = 3;
                break;
            case "Eagle":
                specieSelected = 4;
                break;
            default:
                Debug.LogWarning("Specie not recognized.");
                return;
        }

        playButton.interactable = true;
    }

    public void StartGame() // Inicia la carga de la escena seleccionada
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsynchronously()); // Inicia la carga asíncrona de la escena
    }

    private IEnumerator LoadAsynchronously() // Carga la escena de manera asíncrona y actualiza la barra de carga
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(specieSelected); 
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadbar.value = progress;
            yield return null;
        }
    }
}