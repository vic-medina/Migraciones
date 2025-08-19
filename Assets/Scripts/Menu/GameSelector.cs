using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSelector : MonoBehaviour
{
    [SerializeField] private int specieSelected = 0;
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
        if (specieSelected == 0)
        {
            Debug.LogWarning("No species selected.");
            return;
        }

        SceneManager.LoadScene(specieSelected);
    }
}