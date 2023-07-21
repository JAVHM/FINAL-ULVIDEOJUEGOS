using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScriptEstrella : MonoBehaviour
{
    public float velocidadSeguimiento = 5f; // Velocidad de seguimiento al jugador
    public float distanciaMinimaSeguimiento = 2f; // Distancia mínima para dejar de seguir al jugador
    public float velocidadRecta = 3f; // Velocidad en línea recta después de dejar de seguir al jugador

    private Transform playerT; // Referencia al transform del jugador
    private bool siguiendoJugador = true; // Bandera para indicar si está siguiendo al jugador

    private TrailRenderer trailRenderer;

    // Start is called before the first frame update
    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        playerT = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        trailRenderer.widthMultiplier *= Mathf.Max(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    void FixedUpdate()
    {
        if (siguiendoJugador)
        {
            SeguirJugador();
        }
        else
        {
            MoverEnLineaRecta();
        }
    }

    void SeguirJugador()
    {
        // Calcula la distancia entre el objeto y el jugador
        float distancia = Vector3.Distance(transform.position, playerT.position);

        if (distancia > distanciaMinimaSeguimiento)
        {
            // Si la distancia es mayor a la distancia mínima, sigue al jugador con MoveTowards
            transform.position = Vector3.MoveTowards(transform.position, playerT.position, velocidadSeguimiento * Time.deltaTime);
        }
        else
        {
            // Si la distancia es menor o igual a la distancia mínima, deja de seguir al jugador
            siguiendoJugador = false;
        }
    }

    void MoverEnLineaRecta()
    {
        // Mueve el objeto en línea recta después de dejar de seguir al jugador
        transform.Translate(Vector3.forward * velocidadRecta * Time.deltaTime);
    }
}
