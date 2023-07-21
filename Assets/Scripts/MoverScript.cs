using System.Collections;
using UnityEngine;

public class MoverScript : MonoBehaviour
{
    public float speed = 5f;  // Velocidad de movimiento
    private Vector3 direction; // Dirección aleatoria de movimiento
    [SerializeField] private bool todaDireccion;
    [SerializeField] private bool solovertical;

    void Start()
    {
        // Generar una dirección aleatoria en el eje X y Z
        if (todaDireccion) direction = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
        else if (solovertical)
        {
            direction = new Vector3(0f, Random.Range(-1f, 1f), 0f).normalized;
            StartCoroutine(escalar());
        }
    }

    void Update()
    {
        // Mover el objeto en la dirección aleatoria a una velocidad constante
        transform.position += direction * speed * Time.deltaTime;
    }

    private IEnumerator escalar()
    {
        direction = new Vector3(0f, -direction.y, 0f);
        yield return new WaitForSeconds(1.5f);
        direction = new Vector3(0f, -direction.y, 0f);
        yield return new WaitForSeconds(1.5f);
    }
}
