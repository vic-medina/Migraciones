using System.Collections;
using UnityEngine;

public interface IPlayable
{
    public void Heal(int amountHealed);
    public void OnTakeDamage(int damage, float collision);
    public void Die();
}
