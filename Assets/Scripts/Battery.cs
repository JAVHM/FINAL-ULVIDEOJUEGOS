using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public int amount;
    public bool temp = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && temp)
        {
            temp = false;
            other.transform.parent.gameObject.GetComponent<PlayerEnergy>().GetEnergy(amount);
            Destroy(this.gameObject);
        }
    }
}
