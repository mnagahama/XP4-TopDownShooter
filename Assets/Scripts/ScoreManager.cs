using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{   
    public TextMeshPro scoreText;
    public static int score = 0;
    void Start()
    {
       
    }
    void Update()
    {
        scoreText.text = "Score: " + score;
    }

}
