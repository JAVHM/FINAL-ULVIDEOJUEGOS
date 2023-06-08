using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDistance : MonoBehaviour
{
    public GameObject playerObject;
    public float multiplier = 10;

    private void Start()
    {
        // Buscar el GameObject con el nombre "Player"
        playerObject = GameObject.Find("Player");
    }

    private void Update()
    {
        if (playerObject != null)
        {
            // Calcular la distancia en el eje Z
            float distance = transform.position.z - playerObject.transform.position.z;

            // Si la distancia en el eje Z es mayor a 200, destruir el GameObject
            if (distance + (250 + 200) * multiplier < 0)
            {
                Debug.Log("DEstroy");
                Destroy(gameObject);
            }
        }
    }
}
