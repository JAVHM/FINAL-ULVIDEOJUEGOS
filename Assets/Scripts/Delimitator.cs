using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Delimitator : MonoBehaviour
{
    public Vector2 Y;
    public Vector2 X;
    Vector2 Ytemp;
    Vector2 Xtemp;

    public int margin;
    public bool needChange = false;
    public int distanceToChange = 0;
    public int changePointZ;
    void Update()
    {
        if(needChange && transform.position.z > changePointZ){
            X = Xtemp;
            Y = Ytemp;
            needChange = false;
            Debug.Log("cambiado");
            Debug.Log("X: " + Xtemp);
            Debug.Log("Y: " + Ytemp);
        }
        Vector3 targetPosition = transform.position;
        if (targetPosition.y < Y.x - margin || targetPosition.y > Y.y + margin || targetPosition.x < X.x - margin || targetPosition.x > X.y + margin)
        {
            Debug.Log("fuera de área");
            // Get the index of the current scene
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Reload the current scene by loading it again
            SceneManager.LoadScene(currentSceneIndex);
            //Destroy(this.gameObject);
        }
    }

    public void UpdateLimits(Vector2 newX, Vector2 newY, float dist){
        changePointZ = (int)transform.position.z +(int)dist;
        needChange = true;
        Xtemp = newX;
        Ytemp = newY;
    }
}
