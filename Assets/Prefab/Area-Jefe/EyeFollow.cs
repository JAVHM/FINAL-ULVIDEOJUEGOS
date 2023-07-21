using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollow : MonoBehaviour
{
    public Transform target; // The object the enemy will follow
    public float rotationSpeed = 5f; // Speed at which the enemy rotates towards the target

    void Update()
    {
        if (target != null)
        {
            // Calculate the direction to the target
            Vector3 direction = target.position - transform.position;
            //direction.y = 0f; // Ignore the y-axis to keep the enemy on the same level as the target

            if (direction != Vector3.zero)
            {
                // Calculate the target rotation to look at the target
                Quaternion targetRotation = Quaternion.LookRotation(-direction);

                // Smoothly rotate the enemy towards the target
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
