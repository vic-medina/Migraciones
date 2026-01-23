using DG.Tweening;
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

        [Header("Health UI")]
        [SerializeField] private List<GameObject> heartIcons;

        public void Restart()
        {
            canTakeDamage = true;
            currentHealth = maxHealth;
            UpdateUIHealth(heartIcons.Count);
        }

        public void IncreaseHealth(int amount)
        {
            if (amount <= 0 || currentHealth <= 0) return;
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            UpdateUIHealth(currentHealth);
            return;
        }

        public void ReduceHealth(int amount)
        {
            if (amount <= 0 || currentHealth <= 0) return;
            if(!canTakeDamage) { return; }
            currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
            UpdateUIHealth(currentHealth);
            StartCoroutine(PlayerImmunity());
        }

        public IEnumerator PlayerImmunity()
        {
            canTakeDamage = false;
            yield return new WaitForSeconds(immunityTime);
            canTakeDamage = true;
        }

        private void UpdateUIHealth(int remainingHealt)
        {
            for (int i = 0; i < heartIcons.Count; i++)
            {
                if (i < remainingHealt)
                {
                    heartIcons[i].SetActive(true);
                    heartIcons[i].transform.DOScale(Vector3.one, 0.2f);
                }
                else
                {
                    int index = i;
                    heartIcons[index].transform.DOScale(Vector3.zero, 0.2f).OnComplete(() =>
                    {
                        heartIcons[index].SetActive(false);
                    });
                }
            }
        }
    }
}