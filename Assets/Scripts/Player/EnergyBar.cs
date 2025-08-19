using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;
    [SerializeField]private PlayerMovement playerMovement;
    [SerializeField] private float energyDrainRate = 1f;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        slider.value -= energyDrainRate * Time.deltaTime;
        if (slider.value <= 0)
        {
            slider.value = 0;
            playerMovement.canJump = false;
        }
    }

    public void UseEnergy(float amount)
    {
        slider.value -= amount * Time.deltaTime;
    }
}