using UnityEngine;

public class MenuCharacterSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject[] characters; // array de prefabs

    [Header("Movimiento en X")]
    public float startX;
    public float endX;
    public float speed;

    [Header("Movimiento en Y (onda)")]
    public float amplitude;
    public float frequency;
    public float minAmplitude;
    public float maxAmplitude;
    public float minFrequency;
    public float maxFrequency;
    public float minY;
    public float maxY;

    [Header("Intervalos")]
    public float minInterval;
    public float maxInterval;

    private float timer;
    private float nextInterval;
    private GameObject currentCharacter;

    // valores únicos por instancia
    private float baseY;
    private float startXRef;
    private float randomFrequency;
    private float randomAmplitude;

    // Nuevo flag de control
    private bool allowSpawning = true;

    void Start()
    {
        SetNextInterval();
        timer = nextInterval; // forzar spawn inmediato al inicio
    }

    void Update()
    {
        // Si no está permitido spawnear, no hacemos nada
        if (!allowSpawning) return;

        if (currentCharacter == null)
        {
            timer += Time.deltaTime;

            if (timer >= nextInterval)
            {
                SpawnCharacter();
                timer = 0f;
            }
        }
        else
        {
            float x = currentCharacter.transform.position.x + speed * Time.deltaTime;
            float y = baseY + Mathf.Sin((x - startXRef) * frequency) * amplitude;

            currentCharacter.transform.position = new Vector3(x, y, 0f);

            if (x >= endX)
            {
                Destroy(currentCharacter);
                currentCharacter = null;

                SetNextInterval();
                timer = 0f;
            }
        }
    }

    void SpawnCharacter()
    {
        int index = Random.Range(0, characters.Length);

        baseY = Random.Range(minY, maxY);
        randomFrequency = Random.Range(minFrequency, maxFrequency);
        randomAmplitude = Random.Range(minAmplitude, maxAmplitude);

        amplitude = randomAmplitude;
        frequency = randomFrequency;

        Vector3 spawnPos = new Vector3(startX, baseY, 0f);
        currentCharacter = Instantiate(characters[index], spawnPos, Quaternion.identity);

        startXRef = startX;
    }

    void SetNextInterval()
    {
        nextInterval = Random.Range(minInterval, maxInterval);
        Debug.Log("Next spawn in: " + nextInterval + " seconds.");
    }

    //Métodos públicos para control desde MenuController
    public void AllowSpawning()
    {
        allowSpawning = true;
    }

    public void StopSpawning()
    {
        allowSpawning = false;

        // opcional: limpiar personaje activo si cambias de menú
        if (currentCharacter != null)
        {
            Destroy(currentCharacter);
            currentCharacter = null;
        }
    }
}