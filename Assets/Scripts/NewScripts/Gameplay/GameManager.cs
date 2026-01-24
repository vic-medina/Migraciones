using UnityEngine;
using Pabio.Migraciones.PlayerEssentials;
using UnityEngine.SceneManagement;

namespace Pabio.Migraciones.Managers
{
    public class GameManager : MonoBehaviour
    {
        public HUD playerHUD;
        public UI playerUI;
        public PlayerClass player;
        private bool isPaused = false;
        private bool gameStarted = false;

        void Awake()
        {
            Restart();
        }

        public void Update()
        {
            if (gameStarted && Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused) ResumeGame();
                else PauseGame();
            }
            if (playerUI.initialPanel.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Space))
            {
                BeginGame();
            }
        }


        public void Restart()
        {
            player.Restart();
            playerHUD.Restart();
            playerUI.Restart();
            isPaused = false;
            gameStarted = false;
            LockMouse();
        }

        public void ChangeZone(int index)
        {
            playerHUD.NextLocation(index);
        }

        public void BeginGame()
        {
            player.playerMovement.UnfreezePlayer();
            playerUI.initialPanel.SetActive(false);
            gameStarted = true;
        }

        public void PauseGame()
        {
            player.playerMovement.FreezePlayer();
            playerUI.Pause();
            UnLockMouse();
        }

        public void ResumeGame()
        {
            player.playerMovement.UnfreezePlayer();
            playerUI.Continue();
            LockMouse();
        }

        public void GameOver()
        {
            playerUI.GameOver();
            UnLockMouse();
        }

        public void GameComplete()
        {
            player.playerMovement.StopMovement();
            playerUI.Win();
            playerHUD.HideHUD();
            UnLockMouse();
        }

        public void ChangeScene(int sceneNumber)
        {
            SceneManager.LoadScene(sceneNumber);
        }

        private void LockMouse()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void UnLockMouse()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}