using UnityEngine;
using UnityEngine.UI;

public class GameStandby : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private GameObject startPanel;
    [SerializeField] public Button pauseBtn;

    private bool gameStarted = false;

    void Awake() // Inicializar el juego en pausa
    {
        Time.timeScale = 0;
        pauseBtn.interactable = false;
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
        Time.timeScale = 1;
        startPanel.SetActive(false);
        pauseBtn.interactable = true;
        gameStarted = true;
    }
}