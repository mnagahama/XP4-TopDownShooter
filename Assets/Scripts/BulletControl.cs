using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float destroyDelay = 2; 

    void Start()
    {
       
        Destroy(gameObject, destroyDelay);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Barril" || collision.gameObject.tag == "Barreira")
        {

            Destroy(gameObject);
        }

    }

}
