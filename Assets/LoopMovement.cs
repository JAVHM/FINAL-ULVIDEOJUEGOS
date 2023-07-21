using UnityEngine;

public class LoopMovement : MonoBehaviour
{
    public float speed = 1.0f; // Velocidad del movimiento
    public float distance = 10.0f; // Distancia que recorrerá en el eje X

    private float initialPositionX;

    void Start()
    {
        initialPositionX = transform.position.x;
    }

    void Update()
    {
        // Calcula el desplazamiento en el eje X
        float displacementX = Mathf.PingPong(Time.time * speed, distance);

        // Calcula la nueva posición del objeto
        Vector3 newPosition = new Vector3(initialPositionX + displacementX, transform.position.y, transform.position.z);

        // Aplica la nueva posición al objeto
        transform.position = newPosition;
    }
}