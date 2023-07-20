using UnityEngine;

public class MoverScript : MonoBehaviour
{
    public float speed = 5f;  // Velocidad de movimiento
    private Vector3 direction; // Direcci�n aleatoria de movimiento

    void Start()
    {
        // Generar una direcci�n aleatoria en el eje X y Z
        direction = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }

    void Update()
    {
        // Mover el objeto en la direcci�n aleatoria a una velocidad constante
        transform.position += direction * speed * Time.deltaTime;
    }
}
