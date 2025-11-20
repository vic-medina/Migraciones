using System.Collections;
using UnityEngine;

public class Snake : Enemy
{
    [Header("Referencias")]
    public Transform player;
    public Collider2D attackTrigger;

    private void Update()
    {
        Move(speed);
    }


    protected override void Move(int speed)
    {
        base.Move(speed);
    }

    protected override void OnTriggerEnter2D(Collider2D attackTrigger)
    {
        base.OnTriggerEnter2D(attackTrigger);
    }
}