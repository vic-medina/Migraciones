using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUIController : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pasuePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject mapHUD;
    [SerializeField] private HealtController hltController;

    [Header("Estado del juego")]
    [SerializeField] public bool isPaused;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        pasuePanel.SetActive(false);
        winPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !hltController.gameOver)
        {
           PauseGame();
        }
    }

    public void ContinueGame() // Funcion para continuar el juego desde el menu de pausa
    {
        Time.timeScale = 1;
        pasuePanel.SetActive(false);
        isPaused = false;
    }
    public void PauseGame() // Funcion para pausar el juego y activar el menu de pausa
    {
        Time.timeScale = 0;
        pasuePanel.SetActive(true);
        isPaused = true;
    }
    public void ReturnToMainMenu() // Funcion para volver al menu principal
    {
        Time.timeScale = 1;
        DOTween.KillAll();
        SceneManager.LoadScene(0);
    }

    public void RetryGame(int specie) //Funcion para reintentar el nivel
    {
        DOTween.KillAll();
        Time.timeScale = 1;
        SceneManager.LoadScene(specie);
    }
}
