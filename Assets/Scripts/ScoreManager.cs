using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    

    public TextMeshPro scoreText;
    void Start()
    {
       
    }
    void Update()
    {
        
    }

    public void IncreaseScore(int points)
    {
        score += points; // Aumente a pontuação com a quantidade de pontos especificada
        UpdateScoreText(); // Atualize o componente TextMeshPro com a nova pontuação
    }

    // Método para atualizar o componente TextMeshPro com a nova pontuação
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
