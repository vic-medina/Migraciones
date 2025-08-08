using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;
    [SerializeField]private PlayerController playerController;
    [SerializeField] private float energyDrainRate = 0.1f;

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
            Debug.Log("Energia terminada");
            playerController.canJump = false;
        }
    }

    public void UseEnergy(float amount)
    {
        slider.value -= amount;
    }
}