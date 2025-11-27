using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSelector : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private MenuController menuController;
    [SerializeField] private List<GameObject> gameInfo;
    private bool isLoadingScene = false;
    public Button selectSpecieButton;
    public Button playButton;
    public Button backButton;

    [Header("Especie/Nivel Seleccionado")]
    [SerializeField] private int specieSelected;
    [SerializeField] private int infoSelected;

    private AsyncOperation asyncLoad;

    private void Start() // Inicializa el botón de jugar como no interactivo
    {
        selectSpecieButton.interactable = false;
        playButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        playButton.interactable = false;
    }

    public void SelectSpecie(string specie) // Asigna el nivel basado en la especie seleccionada
    {
        switch (specie)
        {
            case "Bat":
                specieSelected = 1;
                infoSelected = 1;
                break;
            case "DragonFly":
                specieSelected = 2;
                infoSelected = 2;
                break;
            case "Butterfly":
                specieSelected = 3;
                infoSelected = 3;
                break;
            case "Eagle":
                specieSelected = 4;
                infoSelected = 4;
                break;
            default:
                Debug.LogWarning("Specie not recognized.");
                return;
        }

        selectSpecieButton.interactable = true;
    }

    public void ShowGameInfo()
    {
        for (int i = 0; i < gameInfo.Count; i++)
        {
            gameInfo[i].SetActive(i == infoSelected - 1); 
        }
        playButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        StartCoroutine(PreloadScene());
    }

    private IEnumerator PreloadScene()
    {
        if (isLoadingScene) yield break;
        isLoadingScene = true;

        asyncLoad = SceneManager.LoadSceneAsync(specieSelected);
        asyncLoad.allowSceneActivation = false;

        playButton.gameObject.SetActive(true);
        playButton.interactable = true;

        yield return null;
    }

    public void StartGame()
    {
        asyncLoad.allowSceneActivation = true;
    }
}