using System.Collections;
using UnityEngine;

public class Snake : Enemy
{
    [Header("Referencias")]
    public Transform player;
    public Collider2D attackTrigger;

    [Header("Movimiento")]
    [SerializeField] private float verticalSpeed;     // velocidad vertical
    private float verticalDirection;

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
        if (attackTrigger.CompareTag("Player"))
        {
            JumptoPlayer();
        }
    }

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void JumptoPlayer()
    {
        if (player != null)
        {
            Vector3 newPos = transform.position;
            newPos.y = Mathf.Lerp(transform.position.y, player.position.y, Time.deltaTime * verticalSpeed);
            transform.position = newPos;
        }
    }
}