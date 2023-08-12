using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
  public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
        ScoreManager.score = 0;
        PlayerController.health = 3;      
    }
}
