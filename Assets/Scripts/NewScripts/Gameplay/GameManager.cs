using UnityEngine;
using Pabio.Migraciones.PlayerEssentials;
using Pabio.Migraciones.Enemy;
using System.Collections.Generic;

namespace Pabio.Migraciones.Managers
{
    public class GameManager : MonoBehaviour
    {
        public PlayerClass player;
        public List<EnemyClass> enemiesInGame;

        void Awake()
        {
            Restart();
            enemiesInGame.Clear();
        }

        void Start()
        {

        }


        void Update()
        {

        }

        public void Restart()
        {
            player.Restart();
            foreach (var enemies in enemiesInGame)
            {
                enemies.Restart();
            }
        }
    }
}