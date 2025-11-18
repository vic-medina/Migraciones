using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float health = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Player took " + amount + " damage. Remaining health: " + health);
    }
}