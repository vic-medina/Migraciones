using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    [SerializeField] private Vector2 movementSpeed;
    private Vector2 offset;
    private Material material;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        offset += movementSpeed * Time.deltaTime;
        material.mainTextureOffset = offset;
    }
}
