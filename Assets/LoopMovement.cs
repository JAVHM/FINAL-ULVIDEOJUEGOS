using UnityEngine;

public class LoopMovement : MonoBehaviour
{
    public float speed = 1.0f; // Velocidad del movimiento
    public float distance = 10.0f; // Distancia que recorrerá en el eje X
    public float rotationAngle = 180.0f; // Ángulo de rotación en el eje Y

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

        // Calcula la dirección del movimiento en X
        float moveDirection = isMovingForward ? 1.0f : -1.0f;

        // Calcula la nueva posición del objeto en X
        float newPositionX = initialPositionX + moveDirection * displacementX;

        // Aplica la nueva posición al objeto
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);

        // Verifica si el objeto ha completado un loop
        if (isMovingForward && displacementX >= distance)
        {
            // Realiza la rotación si el objeto ha completado un loop en la dirección positiva de X
            transform.Rotate(Vector3.up, rotationAngle);

            // Cambia la dirección del movimiento a negativa
            isMovingForward = false;
        }
        else if (!isMovingForward && displacementX <= 0.0f)
        {
            // Realiza la rotación si el objeto ha completado un loop en la dirección negativa de X
            transform.Rotate(Vector3.up, rotationAngle);

            // Cambia la dirección del movimiento a positiva
            isMovingForward = true;
        }
    }
}
