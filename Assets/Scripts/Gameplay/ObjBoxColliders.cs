using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AutoCollider : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Sprite sprite = sr.sprite;

        // Genera collider según el sprite
        var collider = gameObject.AddComponent<PolygonCollider2D>();
        collider.isTrigger = true;
    }
}
