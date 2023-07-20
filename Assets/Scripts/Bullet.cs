using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float destroyDelay = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Destruido");
        // Autodestruir el GameObject cuando colisiona con cualquier otro objeto
        Destroy(gameObject);
    }
}
