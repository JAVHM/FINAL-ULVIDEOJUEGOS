using UnityEngine;

public class LoopMovement : MonoBehaviour
{
    public float speed = 1.0f; // Velocidad del movimiento
    public float distance = 10.0f; // Distancia que recorrer� en el eje X
    public float rotationAngle = 180.0f; // �ngulo de rotaci�n en el eje Y

    private float initialPositionX;
    private bool isMovingForward = true;

    void Start()
    {
        initialPositionX = transform.position.x;
    }

    void Update()
    {
        // Calcula el desplazamiento en el eje X
        float displacementX = Time.time * speed % distance;

        // Calcula la direcci�n del movimiento en X
        float moveDirection = isMovingForward ? 1.0f : -1.0f;

        // Calcula la nueva posici�n del objeto en X
        float newPositionX = initialPositionX + moveDirection * displacementX;

        // Aplica la nueva posici�n al objeto
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);

        // Verifica si el objeto ha completado un loop
        if (isMovingForward && displacementX >= distance)
        {
            // Realiza la rotaci�n si el objeto ha completado un loop en la direcci�n positiva de X
            transform.Rotate(Vector3.up, rotationAngle);

            // Cambia la direcci�n del movimiento a negativa
            isMovingForward = false;
        }
        else if (!isMovingForward && displacementX <= 0.0f)
        {
            // Realiza la rotaci�n si el objeto ha completado un loop en la direcci�n negativa de X
            transform.Rotate(Vector3.up, rotationAngle);

            // Cambia la direcci�n del movimiento a positiva
            isMovingForward = true;
        }
    }
}
