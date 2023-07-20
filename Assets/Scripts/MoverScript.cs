using UnityEngine;

public class MoverScript : MonoBehaviour
{
    public float speed = 5f;  // Velocidad de movimiento
    private Vector3 direction; // Dirección aleatoria de movimiento

    void Start()
    {
        // Generar una dirección aleatoria en el eje X y Z
        direction = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }

    void Update()
    {
        // Mover el objeto en la dirección aleatoria a una velocidad constante
        transform.position += direction * speed * Time.deltaTime;
    }
}
