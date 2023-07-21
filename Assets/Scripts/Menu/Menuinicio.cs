using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menuinicio : MonoBehaviour
{
    public float rotationSpeed = 30f; // Velocidad de rotación en grados por segundo
    public AudioSource audioS;

    private void Start()
    {
        audioS= GetComponent<AudioSource>();
        audioS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula el ángulo de rotación por fotograma
        float rotationAngle = rotationSpeed * Time.deltaTime;

        // Rota la cámara alrededor del eje Y
        transform.Rotate(Vector3.up, rotationAngle);
    }
}
