using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateZ : MonoBehaviour
{
    public float rotationSpeed = 60f; // Velocidad de rotación en grados por segundo

    void Update()
    {
        // Rotar el objeto en su eje Z a una velocidad constante
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
