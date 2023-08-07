using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);

        }
        
    }
}
