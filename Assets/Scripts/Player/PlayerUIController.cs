using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUIController : MonoBehaviour
{
    public GameObject pauseCanvas;
    public bool isPaused;

    public void ContinueGame()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        isPaused = false;
    }
    public void PuaseGame()
    {
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
        isPaused = true;
    }
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void RetryGame(int specie)
    {
        if (specie >= 1 && specie <= 4) {
            SceneManager.LoadScene(specie);
        }    
        else
            Debug.LogWarning("No se pudo reiniciar");
    }
}
