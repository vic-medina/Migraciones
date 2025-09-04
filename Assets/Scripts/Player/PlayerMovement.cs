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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && canJump && !playerUI.isPaused)
        {
           Fly();
        }
        else if (Input.GetKeyUp(KeyCode.Space) && canJump && !playerUI.isPaused)
        {
            anim.SetBool("fly",false);
        }
        else if (!canJump)
        {
            GameOver();
        }
    }

    private void Fly()
    {
        rb.linearVelocity = new Vector2(0, jumpForce);
        energyBar.UseEnergy(energyCost);
        anim.SetBool("fly",true);
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
    }
}
