using UnityEngine;

public class CameraLookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (!playerTransform) return;

        Vector3 targetPos = transform.position;
        targetPos.x = Mathf.Lerp(
            transform.position.x,
            playerTransform.position.x,
            smoothSpeed * Time.deltaTime
        );

        transform.position = targetPos;
    }
}
