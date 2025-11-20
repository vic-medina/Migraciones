using System.Collections;
using UnityEngine;

public class Owl : Enemy
{
    [Header("Referencias")]
    public Transform player;

    [Header("Movimiento")]
    [SerializeField] private float verticalSpeed;     // velocidad vertical
    [SerializeField] private float changeTime;        // cada cuánto cambia dirección Y
    private float verticalDirection;

    private void Update()
    {
        Move(speed);
    }

    protected override void Move(int speed)
    {
        base.Move(speed);

        if (player != null)
        {
            Vector3 newPos = transform.position;
            newPos.y = Mathf.Lerp(transform.position.y, player.position.y, Time.deltaTime * verticalSpeed);
            transform.position = newPos;
        }
    }

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}