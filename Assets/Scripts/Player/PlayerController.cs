using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private EntityPool foodPool;
    [SerializeField] private EntityPool enemyPool;
    [SerializeField] private EnergyBar energyBar;
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private float foodValue;
    [SerializeField] private float enemyDamage;
    [SerializeField] private float objectDamage;
    [SerializeField] private float cooldownTime;
    [SerializeField] private bool canTakeDamage;

    private void Start()
    {
        Time.timeScale = 1;
        canTakeDamage = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            energyBar.slider.value += foodValue;
            foodPool.ReturnToPool(collision.gameObject);
        }
        else if (collision.CompareTag("Enemy"))
        {
            energyBar.slider.value -= enemyDamage;
            enemyPool.ReturnToPool(collision.gameObject);
        }
        else if (collision.CompareTag("FinishLine"))
        {
            Time.timeScale = 0f;
            finishPanel.SetActive(true);
        }
        else if (canTakeDamage && collision.CompareTag("DamageObject"))
        {
            TakeDamageWithCooldown(objectDamage, cooldownTime);
        }
    }

    private void TakeDamageWithCooldown(float damage, float cooldown)
    {
        energyBar.slider.value -= damage;
        StartCoroutine(DamageCooldown(cooldown));
    }

    private IEnumerator DamageCooldown(float cooldown)
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(cooldown);
        canTakeDamage = true;
    }

}