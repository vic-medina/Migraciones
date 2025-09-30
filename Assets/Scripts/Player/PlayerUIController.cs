using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUIController : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private GameObject pasuePanel;

    [Header("Estado del juego")]
    [SerializeField] public bool isPaused;

    public void ContinueGame() // Funcion para continuar el juego desde el menu de pausa
    {
        Time.timeScale = 1;
        pasuePanel.SetActive(false);
        isPaused = false;
    }
    public void PuaseGame() // Funcion para pausar el juego y activar el menu de pausa
    {
        Time.timeScale = 0;
        pasuePanel.SetActive(true);
        isPaused = true;
    }
    public void ReturnToMainMenu() // Funcion para volver al menu principal
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void RetryGame(int specie) // Funcion para reiniciar el nivel actual
    {
        SceneManager.LoadScene(specie);
    }
}
