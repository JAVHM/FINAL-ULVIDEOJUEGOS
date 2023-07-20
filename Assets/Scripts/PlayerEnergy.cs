using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{
    public float maxEnergy = 100f; // Energ�a m�xima del avi�n
    public float currentEnergy;   // Energ�a actual del avi�n

    public Slider energySlider;   // Referencia al Slider UI

    void Start()
    {
        currentEnergy = maxEnergy; // Establecer la energ�a inicial al m�ximo
        UpdateEnergyUI();          // Actualizar el Slider UI con el valor inicial
    }

    void Update()
    {
        // Reducir la energ�a del avi�n con el tiempo
        currentEnergy -= Time.deltaTime;

        // Asegurarse de que la energ�a nunca sea negativa
        currentEnergy = Mathf.Max(currentEnergy, 0f);

        UpdateEnergyUI(); // Actualizar el Slider UI con el nuevo valor de energ�a
    }

    void UpdateEnergyUI()
    {
        // Actualizar el valor del Slider UI
        energySlider.value = currentEnergy / maxEnergy;
    }
}
