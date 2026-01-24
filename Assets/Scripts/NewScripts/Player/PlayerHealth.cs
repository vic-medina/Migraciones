using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pabio.Migraciones.PlayerEssentials
{
    public class PlayerHealth : MonoBehaviour
    {
        [Header("HealthStats")]
        [SerializeField] private int maxHealth;
        public int currentHealth;
        public float immunityTime;
        public bool canTakeDamage;

        [Header("Health HUD")]
        [SerializeField] private List<GameObject> heartIcons;

        public void Restart()
        {
            canTakeDamage = true;
            currentHealth = maxHealth;
            UpdateHUDHealth(currentHealth);
        }

        public void IncreaseHealth(int amount)
        {
            if (amount <= 0 || currentHealth <= 0) return;
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            UpdateHUDHealth(currentHealth);
            return;
        }

        public void ReduceHealth(int amount)
        {
            if (amount <= 0 || currentHealth <= 0) return;
            if(!canTakeDamage) { return; }
            currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
            UpdateHUDHealth(currentHealth);
            StartCoroutine(PlayerImmunity());
        }

        private IEnumerator PlayerImmunity()
        {
            canTakeDamage = false;
            yield return new WaitForSeconds(immunityTime);
            canTakeDamage = true;
        }

        private void UpdateHUDHealth(int remainingHealt)
        {
            for (int i = 0; i < heartIcons.Count; i++)
            {
                if (i < remainingHealt)
                {
                    heartIcons[i].transform.DOScale(Vector3.one, 0.2f).OnComplete(() =>
                    {
                        heartIcons[i].SetActive(true);
                    });
                }
                else
                {
                    //int index = i;
                    heartIcons[i].transform.DOScale(Vector3.zero, 0.2f).OnComplete(() =>
                    {
                        heartIcons[i].SetActive(false);
                    });
                }
            }
        }
    }
}