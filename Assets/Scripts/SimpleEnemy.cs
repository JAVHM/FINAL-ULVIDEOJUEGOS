using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleEnemy : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float detectionDistance = 10f; // Distancia para detectar al jugador
    public float blockingDistance = 5f; // Distancia para bloquear el avance del jugador

    public float movementSpeed = 5f; // Velocidad de movimiento del enemigo

    private bool playerDetected = false;

    public int health;

    void Start()
    {
        // Buscar el objeto "Player" y obtener su transform
        player = GameObject.Find("Player").transform;

        if (player == null)
        {
            Debug.LogError("El objeto 'Player' no fue encontrado en la escena. Asegúrate de que el nombre del objeto sea correcto.");
        }
    }

    void Update()
    {
        if (player == null)
            return; // Salir del Update si el jugador no está presente

        // Calcular la distancia entre el enemigo y el jugador en el plano XY (eje X e Y)
        float distanceToPlayer = Vector2.Distance(new Vector2(transform.position.x, transform.position.y),
                                                  new Vector2(player.position.x, player.position.y));

        if (!playerDetected && distanceToPlayer <= detectionDistance)
        {
            playerDetected = true;
        }

        if (playerDetected && distanceToPlayer > blockingDistance)
        {
            // Calcular la dirección hacia el jugador en el plano XY (eje X e Y)
            Vector2 targetDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y).normalized;

            // Calcular el ángulo de rotación hacia la dirección del jugador
            float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

            // Moverse hacia la posición deseada (en frente del jugador)
            Vector3 newPosition = Vector3.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);

            // Rotar hacia la dirección del jugador
            float currentAngle = Mathf.Atan2(transform.up.y, transform.up.x) * Mathf.Rad2Deg;
            float angle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, Time.deltaTime * movementSpeed);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    bool temp = true;
    public int looseAmount;
    public GameObject floatingText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && temp)
        {
            temp = false;
            other.transform.parent.gameObject.GetComponent<PlayerEnergy>().GetEnergy(looseAmount);
            Destroy(this.gameObject);
        }

        if (other.CompareTag("PlayerBullet") && temp)
        {
            health -= 1;
            if(health <= 0)
            {
                Debug.Log("AAAAAAAAAA");
                var t = Instantiate(floatingText, other.gameObject.transform.position, Quaternion.identity);
                t.GetComponent<TextMeshPro>().text = health.ToString();
                Destroy(this.gameObject);
            } 
        }
    }
}
