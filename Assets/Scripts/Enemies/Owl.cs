using System.Collections;
using UnityEngine;

public class Owl : Enemy
{
    [Header("Movimiento")]
    [SerializeField] private int speed;
    [SerializeField] private float verticalSpeed;     // velocidad vertical
    [SerializeField] private float changeTime; // cada cuánto cambia dirección Y
    private float randomY;

    void FixedUpdate()
    {
        Move(speed);
    }

    private void OnEnable()
    {
        StartCoroutine(UpdateVerticalDirection());
    }

    private IEnumerator UpdateVerticalDirection()
    {
        while (true)
        {
            randomY = Random.Range(-1f, 1f); // dirección vertical aleatoria
            yield return new WaitForSeconds(changeTime);
        }
    }

    protected override void Move(int speed)
    {
        base.Move(speed);

        Vector2 currentVelocity = rb2D.linearVelocity;
        currentVelocity.y = randomY * verticalSpeed;
        rb2D.linearVelocity = currentVelocity;
    }
}