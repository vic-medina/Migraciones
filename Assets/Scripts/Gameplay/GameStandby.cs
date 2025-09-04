using UnityEngine;
using UnityEngine.UI;

public class GameStandby : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private GameObject startPanel;
    [SerializeField] public Button pauseButton;

    private bool gameStarted = false;

    void Awake() // Inicializar el juego en pausa
    {
        Time.timeScale = 0;
        pauseButton.interactable = false;
    }

    void Update() 
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space)) // Iniciar el juego al presionar la barra espaciadora
        {
            StartGame();
        }
    }

    public void StartGame() // Método para iniciar el juego
    {
        gameStarted = true;
        Time.timeScale = 1;
        startPanel.SetActive(false);
        pauseButton.interactable = true;
    }
}