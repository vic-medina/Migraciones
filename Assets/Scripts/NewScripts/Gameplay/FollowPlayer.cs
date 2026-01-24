using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private void FixedUpdate()
    {
        if (!playerTransform) return;

        Vector3 targetPos = transform.position;
        targetPos.x = playerTransform.position.x;
        transform.position = targetPos;
    }
}
