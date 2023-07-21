using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Transform target;
    public float maxSpeed = 5000f;
    public float minSpeed = 10f;
    public float defaultSpeed = 2500f;

    void Update()
    {
        float zDifference = target.position.z - transform.position.z;

        // Determine the speed based on the Z difference
        float speed = defaultSpeed;
        if (Mathf.Abs(zDifference) < 4000f)
        {
            speed = maxSpeed;
        }
        else if (Mathf.Abs(zDifference) > 10000f)
        {
            speed = minSpeed;
        }

        // Move the object in the Z direction with the calculated speed
        float movement = Mathf.Clamp(zDifference, -1f, 1f) * speed * Time.deltaTime;
        transform.Translate(0f, 0f, movement);

        if (target == null)
            return; // Salir del Update si el jugador no está presente

        // Calcular la distancia entre el enemigo y el jugador en el plano XY (eje X e Y)
        float distanceToPlayer = Vector2.Distance(new Vector2(transform.position.x, transform.position.y),
                                                  new Vector2(target.position.x, target.position.y));

        // Calcular la dirección hacia el jugador en el plano XY (eje X e Y)
        Vector2 targetDirection = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y).normalized;


        // Moverse hacia la posición deseada (en frente del jugador)
        Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position + new Vector3(0,200,0), 5000 * Time.deltaTime);
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }
}
