using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerEnergy : MonoBehaviour
{
    public float maxEnergy = 100f; // Energ�a m�xima del avi�n
    public float currentEnergy;   // Energ�a actual del avi�n

    public Slider energySlider;   // Referencia al Slider UI
    public float multiplier;

    void Start()
    {
        currentEnergy = maxEnergy; // Establecer la energ�a inicial al m�ximo
        UpdateEnergyUI();          // Actualizar el Slider UI con el valor inicial
    }

    void Update()
    {
        // Reducir la energ�a del avi�n con el tiempo
        currentEnergy -= Time.deltaTime * multiplier;

        // Asegurarse de que la energ�a nunca sea negativa
        currentEnergy = Mathf.Max(currentEnergy, 0f);

        UpdateEnergyUI(); // Actualizar el Slider UI con el nuevo valor de energ�a

        if(currentEnergy == 0){EnergyDeath();}
    }

    void UpdateEnergyUI()
    {
        // Actualizar el valor del Slider UI
        energySlider.value = currentEnergy / maxEnergy;
    }

    public void GetEnergy(int e)
    {
        currentEnergy += e;
        if (currentEnergy >= maxEnergy)
            currentEnergy = maxEnergy;
    }

    void EnergyDeath()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }
}
