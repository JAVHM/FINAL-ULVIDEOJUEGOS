using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProbability : MonoBehaviour
{
    public int probability = 50; // Probabilidad de autodestrucción (de 0 a 100)

    // Start is called before the first frame update
    void Start()
    {
        // Generar un número aleatorio entre 0 y 100
        int randomValue = Random.Range(0, 101);

        // Comprobar si el número aleatorio es menor que la probabilidad definida
        if (randomValue < probability)
        {
            Debug.Log("Destroy");
            Destroy(gameObject); // Destruir el objeto actual
        }
    }
}
