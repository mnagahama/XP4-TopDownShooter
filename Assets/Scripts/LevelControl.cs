using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public int barrisParaDestruir = 5;
    private int barrisDestruidos = 0;
    //public int inimigosPraraDestruir = 5;
    //private int inimigosDestruidos = 0;

    public void BarrisDestruidos()
    {
        barrisDestruidos++;
        //inimigosDestruidos++;
        

        if (barrisDestruidos >= barrisParaDestruir)
        {
            StartCoroutine(waiter());
        }

    }

     IEnumerator waiter()
    {    
        yield return new WaitForSeconds(2);

        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("Fase2");
    }

}
