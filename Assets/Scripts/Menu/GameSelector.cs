using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSelector : MonoBehaviour
{
    [SerializeField] private MenuController menuController;
    private int specieSelected;

    private AsyncOperation asyncLoad;

    private void Start()
    {
    }

    public void Restart()
    {
        specieSelected = 0;
    }

    public void SelectSpecie(int specieID)
    {
        menuController.ChangeScreenTo(specieID);
        specieSelected = specieID;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(specieSelected);
    }
}