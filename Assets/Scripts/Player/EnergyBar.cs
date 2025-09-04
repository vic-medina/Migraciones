using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] public Slider slider;
    [SerializeField] private PlayerMovement playerMovement;

    [Header("Costo de Energia")]
    [SerializeField] private float energyDrainRate = 1f;

    private void Start()
    {
        slider = GetComponent<Slider>(); // Asegúrate de que el Slider esté asignado
    }

    private void Update()
    {
        EnergyDrain(energyDrainRate); // Drena energía constantemente   
    }

    public void EnergyDrain(float drain) // Funcion para drenar energia
    {
        slider.value -= drain * Time.deltaTime;
        if (slider.value <= 0) // Si la energia llega a 0, el jugador no puede saltar
        {
            slider.value = 0;
            playerMovement.canJump = false;
        }
    }

    public void UseEnergy(float amount) // Funcion para usar energia al saltar
    {
        slider.value -= amount * Time.deltaTime;
    }
}