using UnityEngine;

public class MoveInNegativeZ : MonoBehaviour
{
    public float speed = 5.0f; // Velocidad del movimiento en el eje Z

    void Update()
    {
        // Calcula el desplazamiento en el eje Z según la velocidad y el tiempo
        float displacementZ = speed * Time.deltaTime;

        // Calcula la nueva posición del objeto en el eje Z
        Vector3 newPosition = transform.position - new Vector3(0, 0, displacementZ);

        // Aplica la nueva posición al objeto
        transform.position = newPosition;
    }
}