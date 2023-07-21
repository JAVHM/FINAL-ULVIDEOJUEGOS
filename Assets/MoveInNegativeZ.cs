using UnityEngine;

public class MoveInNegativeZ : MonoBehaviour
{
    public float speed = 5.0f; // Velocidad del movimiento en el eje Z

    void Update()
    {
        // Calcula el desplazamiento en el eje Z seg�n la velocidad y el tiempo
        float displacementZ = speed * Time.deltaTime;

        // Calcula la nueva posici�n del objeto en el eje Z
        Vector3 newPosition = transform.position - new Vector3(0, 0, displacementZ);

        // Aplica la nueva posici�n al objeto
        transform.position = newPosition;
    }
}