using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalNewArea : MonoBehaviour
{
    public GameObject generator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Hacer algo cuando el objeto "Player" toque el objeto "Plane"
            Debug.Log("¡El jugador ha tocado el plano!");

            // Obtener la posición del objeto padre
            Vector3 spawnPosition = transform.position;

            // Instanciar el objeto y asignarle la posición del objeto padre
            GameObject newObject = Instantiate(generator, spawnPosition, Quaternion.identity);

            newObject.GetComponent<TGen>().target = other.gameObject.transform;
        }
    }
}
