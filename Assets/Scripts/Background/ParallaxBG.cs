using UnityEngine;
public class ParallaxBG : MonoBehaviour
{
    [Header("Velocidad")]
    [SerializeField] public Vector2 movementSpeed;

    private Vector2 offset;
    private Material material;

    private void Awake() //Inicializar el material
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update() //Actualizar el offset de la textura para crear el efecto parallax
    {
        offset += movementSpeed * Time.deltaTime;
        material.mainTextureOffset = offset;
    }
}
