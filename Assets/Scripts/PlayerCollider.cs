using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour
{
    // Specify the tag of the objects to destroy the collider
    public string obstacleTag = "Obstacle";
    public string portalTag = "Portal";

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the specified tag
        if (collision.gameObject.CompareTag(obstacleTag))
        {
            // Get the index of the current scene
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Reload the current scene by loading it again
            SceneManager.LoadScene(currentSceneIndex);
        }
        if (collision.gameObject.CompareTag(obstacleTag))
        {
            Debug.Log("AAAAAAAAAAA");
        }
    }
}
