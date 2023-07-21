using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health;

    void Start()
    {
    }

    void Update()
    {
    }

    bool temp = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet") && temp)
        {
            health -= 1;
            if(health <= 0)
            {
                Debug.Log("AAAAAAAAAA");
                Destroy(this.gameObject);
            } 
        }
    }
}
