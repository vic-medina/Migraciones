using UnityEngine;
using Pabio.Migraciones.Enemy;

namespace Pabio.Migraciones.Enemy
{
    public class Owl : EnemyClass
    {
        [Header("MovementAdded")]
        [SerializeField] private float verticalSpeed;

        private void FixedUpdate()
        {
            BaseMovement(speed);
        }

        protected override void BaseMovement(int speed)
        {
            base.BaseMovement(speed);

            if (player != null)
            {
                Vector3 newPos = transform.position;
                newPos.y = Mathf.Lerp(transform.position.y, player.position.y, Time.deltaTime * verticalSpeed);
                transform.position = newPos;
            }
        }
    }
}