using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private EnergyBar energyBar;
    [SerializeField] private GameObject finishPanel;
    private Rigidbody2D rb;

    [Header("Comida")]
    [SerializeField] private float foodValue;

    [Header("Enemigos y Objetos")]
    [SerializeField] private float enemyDamage;
    [SerializeField] private float objectDamage;
    [SerializeField] private float cooldownTime;
    [SerializeField] private bool canTakeDamage;

    private void Start()
    {
        canTakeDamage = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) // Detecta colisiones dependiedno la etiqueta de los objetos
    {
        if (collision.CompareTag("Food")) // La comida suma energia y vuelve al pool
        {
            energyBar.PlusEnergy(foodValue);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Enemy")) // Los enemigos restan energia
        {
            TakeDamageWithCooldown(enemyDamage, cooldownTime);
        }
        else if (collision.CompareTag("FinishLine")) // La linea de meta pausa el juego y muestra el panel de finalizacion
        {
            Time.timeScale = 0f;
            finishPanel.SetActive(true);
        }
        else if (canTakeDamage && collision.CompareTag("DamageObject")) // Los objetos en el mundo que hacen daño restan energia
        {
            TakeDamageWithCooldown(objectDamage, cooldownTime);
        }
    }

    private void TakeDamageWithCooldown(float damage, float cooldown) // Resta energia y activa el cooldown para no recibir daño constantemente
    {
        energyBar.slider.value -= damage;
        Debug.Log("Player took damage: " + damage);
        StartCoroutine(DamageCooldown(cooldown));
    }

    private IEnumerator DamageCooldown(float cooldown) // Coroutine para el cooldown de recibir daño
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(cooldown);
        canTakeDamage = true;
    }

}