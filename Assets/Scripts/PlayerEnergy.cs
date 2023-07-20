using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{
    public float maxEnergy = 100f; // Energía máxima del avión
    public float currentEnergy;   // Energía actual del avión

    public Slider energySlider;   // Referencia al Slider UI

    void Start()
    {
        currentEnergy = maxEnergy; // Establecer la energía inicial al máximo
        UpdateEnergyUI();          // Actualizar el Slider UI con el valor inicial
    }

    void Update()
    {
        // Reducir la energía del avión con el tiempo
        currentEnergy -= Time.deltaTime;

        // Asegurarse de que la energía nunca sea negativa
        currentEnergy = Mathf.Max(currentEnergy, 0f);

        UpdateEnergyUI(); // Actualizar el Slider UI con el nuevo valor de energía
    }

    void UpdateEnergyUI()
    {
        // Actualizar el valor del Slider UI
        energySlider.value = currentEnergy / maxEnergy;
    }
}
