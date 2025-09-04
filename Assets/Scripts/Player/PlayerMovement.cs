using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private EnergyBar energyBar;
    [SerializeField] private PlayerUIController playerUI;
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Parametros movimiento")]
    [SerializeField] private float jumpForce;
    [SerializeField] public bool canJump;

    [Header("Energia")]
    [SerializeField] private float energyCost;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && canJump && !playerUI.isPaused) // Mientras se mantenga presionada la barra espaciadora y haya energia, el jugador salta
        {
           Fly();
        }
        else if (Input.GetKeyUp(KeyCode.Space) && canJump && !playerUI.isPaused) // Al soltar la barra espaciadora se desactiva la animacion de vuelo
        {
            anim.SetBool("fly",false);
        }
        else if (!canJump) //Game Over si no hay energia
        {
            GameOver();
        }
    }

    private void Fly() // Funcion para saltar y gastar energia
    {
        rb.linearVelocity = new Vector2(0, jumpForce);
        energyBar.UseEnergy(energyCost);
        anim.SetBool("fly",true);
    }

    private void GameOver() // Funcion para activar el Game Over
    {
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
    }
}
