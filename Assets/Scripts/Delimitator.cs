using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Xtemp = X;
            Ytemp = Y;
            needChange = false;
            Debug.Log("cambiado");
        }
        Vector3 targetPosition = transform.position;
        if (targetPosition.y < Y.x - margin || targetPosition.y > Y.y + margin || targetPosition.x < X.x - margin || targetPosition.x > X.y + margin)
        {
            Destroy(this.gameObject);
        }
    }

    public void UpdateLimits(Vector2 newX, Vector2 newY, float dist){
        changePointZ = (int)transform.position.z +(int)dist;
        needChange = true;
        Xtemp = newX;
        Ytemp = newY;
    }
}
