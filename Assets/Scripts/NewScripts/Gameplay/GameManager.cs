using UnityEngine;
using Pabio.Migraciones.PlayerEssentials;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using System.Collections.Generic;

namespace Pabio.Migraciones.Managers
{
    public class GameManager : MonoBehaviour
    {
        public HUD playerHUD;
        public UI playerUI;
        public PlayerClass player;
        public Background backgroundController;
        public BackGroundSwitch backGroundSwitch;
        private bool isPaused = false;
        private bool gameStarted = false;

        public EntityReleaser entityReleaser;
        public SpawnerManager spawnerManager;

        public List<MovibleObjects> movibleObjects = new List<MovibleObjects>();

        void Start()
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

            backGroundSwitch.Restart();
            backgroundController.Restart();

            entityReleaser.ReturnAllToPool();
            spawnerManager.Restart();

            foreach (var item in movibleObjects)
            {
                item.Restart();
            }

            var foods = GameObject.FindGameObjectsWithTag("Food");
            foreach (var food in foods)
            {
                food.SetActive(true);
            }

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
            backgroundController.UnfreezeBackground();
            playerUI.initialPanel.SetActive(false);
            gameStarted = true;
        }

        public void PauseGame()
        {
            player.playerMovement.FreezePlayer();
            backgroundController.FreezeBackground();
            playerUI.Pause();
            UnLockMouse();
        }

        public void ResumeGame()
        {
            player.playerMovement.UnfreezePlayer();
            backgroundController.UnfreezeBackground();
            playerUI.Continue();
            LockMouse();
        }

        public void GameOver()
        {
            player.playerMovement.StopMovement();
            playerUI.GameOver();
            backgroundController.FreezeBackground();
            UnLockMouse();
        }

        public void GameComplete()
        {
            player.playerMovement.StopMovement();
            backgroundController.FreezeBackground();
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