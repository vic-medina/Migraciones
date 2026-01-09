using System.Collections;
using UnityEngine;

public class Spider : Enemy
{
    [Header("Referencias")]
    public Transform player;
    public Collider2D attackTrigger;

    private void Update()
    {
        Move(speed);
    }
}