using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float spawnInterval = 1f; // Intervalo de tiempo en segundos entre la generación de proyectiles.

    private bool isFiring = false;
    private float timeSinceLastSpawn = 0f;
    public float minForce;
    public float force;
    public float maxForce;

    private void Update()
    {
        // Detectar si se presiona o suelta el clic derecho
        if (Input.GetMouseButtonDown(0))
        {
            isFiring = true;
            timeSinceLastSpawn = 0f;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isFiring = false;
        }

        // Si está presionado el clic derecho y ha pasado el tiempo del intervalo, disparamos el proyectil.
        if (isFiring)
        {
            timeSinceLastSpawn += Time.deltaTime;

            if (timeSinceLastSpawn >= spawnInterval)
            {
                FireProjectile();
                timeSinceLastSpawn = 0f;
            }
        }
    }

    private void FireProjectile()
    {
        GameObject newProjectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = newProjectile.GetComponent<Rigidbody>();

        // Aplicar una fuerza hacia adelante al proyectil para que se mueva en la dirección del FirePoint
        rb.AddForce(newProjectile.transform.forward * force, ForceMode.Force);
    }
}
