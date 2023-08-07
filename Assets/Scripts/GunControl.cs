using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    public Transform spawnPoint;
    void Start()
    {
        spawnPoint = transform.GetChild(0);
    }
       
    void Update()
    {
    }
  
}
