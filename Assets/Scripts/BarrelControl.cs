using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelControl : MonoBehaviour
{
    //public int health = 1;
    public LevelControl levelControl;
    public int points = 1;

    void OnDestroy()
    {
        // Obtenha uma refer�ncia ao objeto que cont�m o script "ScoreManager"
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

        // Se encontrarmos o objeto "ScoreManager", aumente a pontua��o com a quantidade de pontos definida
        if (scoreManager != null)
        {
            scoreManager.IncreaseScore(points);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            levelControl.BarrisDestruidos();
            Destroy(gameObject);
        }
        
    }
}
