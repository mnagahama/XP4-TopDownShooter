using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    Rigidbody rb;
    PlayerController playerReference;
    public float movespeed = 2;
    public int points = 3;
    public int health = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerReference = GameObject.FindObjectOfType<PlayerController>();

    }

    
    void Update()
    {
        transform.LookAt(playerReference.transform.position);
        if (health <= 0)
        {
            ScoreManager.score += 3;
            Destroy(this.gameObject);

        }

    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * movespeed;      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health--;
        }
    }



}
