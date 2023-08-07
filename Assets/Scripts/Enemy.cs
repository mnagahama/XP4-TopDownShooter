using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    public int life = 10;
    PlayerController playerReference;
    public float movespeed = 3;
    public int points = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerReference = GameObject.FindObjectOfType<PlayerController>();
    }

    
    void Update()
    {
        transform.LookAt(playerReference.transform.position);

        if (life <= 0)
            Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * movespeed;    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            life--;
        }
    }

    void OnDestroy()
    {
        // Obtenha uma referência ao objeto que contém o script "ScoreManager"
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

        // Se encontrarmos o objeto "ScoreManager", aumente a pontuação com a quantidade de pontos definida
        if (scoreManager != null)
        {
            scoreManager.IncreaseScore(points);
        }
    }
}
