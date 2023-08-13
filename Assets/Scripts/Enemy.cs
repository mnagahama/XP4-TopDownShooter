using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    PlayerController playerReference;
    public float movespeed = 2;
    public int points = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerReference = GameObject.FindObjectOfType<PlayerController>();
    }

    
    void Update()
    {
        transform.LookAt(playerReference.transform.position);

    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * movespeed;    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            ScoreManager.score += 1;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

}
