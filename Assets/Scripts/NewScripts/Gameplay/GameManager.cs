using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Pabio.Migraciones.PlayerMovement playerMov;
    public PlayerClass player;
    public PlayerHealt playerHealt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Restart();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        playerHealt.Restart();
        playerMov.Restart();
        player.Restart();
    }
}
