using UnityEngine;
using Pabio.Migraciones;

public abstract class PlayerClass : MonoBehaviour, IPlayable
{
    public string speciesName;
    public int maxHealth;
    private int currentHealt;

    [SerializeField] private bool canTakeDamage;

    [SerializeField] protected Pabio.Migraciones.PlayerMovement playerMovement;
    [SerializeField] protected PlayerHealt playerHealt;

    protected virtual void Awake()
    {
        Restart();
    }

    public virtual void Restart()
    {
        canTakeDamage = true;
        currentHealt = maxHealth;
    }

    public virtual void OnTakeDamage(int damage, float collision)
    {
        canTakeDamage = false;

        if (damage <= 0 || currentHealt <= 0) return;

        currentHealt = Mathf.Clamp(currentHealt - damage, 0, maxHealth);
        Debug.Log($"{speciesName} recibe {damage}. Salud: {currentHealt}");

        playerMovement?.ApplyKnockback(collision);
        playerHealt?.UpdateUIHealt(currentHealt);

        canTakeDamage = true;

        if (currentHealt == 0)
            Die();
    }

    public virtual void Heal(int amount)
    {
        if (amount <= 0 || currentHealt <= 0) return;

        currentHealt = Mathf.Clamp(currentHealt + amount, 0, maxHealth);
        Debug.Log($"{speciesName} se cura {amount}. Salud: {currentHealt}");

        playerHealt?.UpdateUIHealt(currentHealt);
    }

    public void Die()
    {
        playerMovement?.StopMovement();
        Debug.Log($"{speciesName} ha muerto");
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Food":
                Heal(1);
                break;
            case "Obstacle":
                if(!canTakeDamage) return;
                var collisionY = collision.transform.position.y;
                OnTakeDamage(1,collisionY);
                break;
        }
    }
}