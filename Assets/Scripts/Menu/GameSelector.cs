using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSelector : MonoBehaviour
{
    [SerializeField] private int specieSelected = 0;
    [SerializeField] private Slider loadbar;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] public Button playButton;

    private void Start()
    {
        playButton.interactable = false;
    }

    public void SelectSpecie(string specie)
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

    public void StartGame()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
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