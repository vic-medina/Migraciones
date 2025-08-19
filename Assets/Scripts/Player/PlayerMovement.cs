using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private EnergyBar energyBar;
    [SerializeField] private PlayerUIController playerUI;
    [SerializeField] private float jumpForce;
    [SerializeField] private float energyCost;
    [SerializeField] public bool canJump;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && canJump && !playerUI.isPaused)
        {
            rb.linearVelocity = new Vector2(0, jumpForce);
            energyBar.UseEnergy(energyCost);
        }
        else if (!canJump)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
    }
}
