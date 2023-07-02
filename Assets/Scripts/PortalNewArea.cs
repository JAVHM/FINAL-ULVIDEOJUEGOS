using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PortalNewArea : MonoBehaviour
{
    public GameObject generator;
    bool canInst = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canInst)
        {
            canInst = false;
            // Obtener la posición del objeto padre
            Vector3 spawnPosition = transform.position;

            // Hacer algo cuando el objeto "Player" toque el objeto "Plane"
            //Debug.Log("¡El jugador ha tocado el plano! " + spawnPosition);

            // Instanciar el objeto y asignarle la posición del objeto padre
            GameObject newObject = Instantiate(generator, new Vector3(spawnPosition.x, spawnPosition.y,spawnPosition.z + 750 * 30), Quaternion.identity);

            newObject.GetComponent<TGen>().target = other.gameObject.transform;
        }
    }
}
