using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private EnergyBar energyBar;
    [SerializeField] private PlayerUIController playerUI;
    [SerializeField] private float jumpForce;
    [SerializeField] private float energyCost;
    [SerializeField] public bool canJump;
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
