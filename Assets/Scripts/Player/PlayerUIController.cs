using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUIController : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject playerPanel;
    [SerializeField] private GameObject pasuePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private HealtController hltController;

    [Header("Estado del juego")]
    [SerializeField] public bool isPaused;
    [SerializeField] private float waitTimetoFinal;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        pasuePanel.SetActive(false);
        winPanel.SetActive(false);
        finalPanel.SetActive(false);
        creditsPanel.SetActive(false);
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

    public void GotoFinalPanel() // Funcion para ir al panel final despues de los creditos
    {
        StartCoroutine(WaitAndShowFinalPanel());
    }

    public void GotoCredits()
    {
        finalPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void RetryGame(int specie) //Funcion para reintentar el nivel
    {
        DOTween.KillAll();
        Time.timeScale = 1;
        SceneManager.LoadScene(specie);
    }

    private IEnumerator WaitAndShowFinalPanel()
    {
        yield return new WaitForSeconds(waitTimetoFinal);
        winPanel.SetActive(false);
        finalPanel.SetActive(true);
    }
}
