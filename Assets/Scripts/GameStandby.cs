using UnityEngine;
using UnityEngine.UI;

public class GameStandby : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] public Button pauseButton;
    private bool gameStarted = false;

    void Awake()
    {
        Time.timeScale = 0;
        pauseButton.interactable = false;
    }

    void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        gameStarted = true;
        Time.timeScale = 1;
        startPanel.SetActive(false);
        pauseButton.interactable = true;
    }
}