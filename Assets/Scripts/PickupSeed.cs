using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickupSeed : MonoBehaviour
{
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController playerReference;
            playerReference = GameObject.FindObjectOfType<PlayerController>();
            playerReference.AddAmmo();
            Destroy(other.gameObject);
        }

    }

}
