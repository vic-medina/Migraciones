using UnityEngine;

public class CameraLookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private float playerOffset;

    void LateUpdate()
    {
        if (!playerTransform) return;

        Vector3 targetPos = transform.position;
        targetPos.x = Mathf.Lerp(transform.position.x, playerTransform.position.x + playerOffset, smoothSpeed * Time.deltaTime);
        transform.position = targetPos;
    }
}
