using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeUIManager : MonoBehaviour
{

    IEnumerator waitAndLoad(float waitTime){
        yield return new WaitForSeconds(waitTime);      
        SceneManager.LoadScene("Level1");  
    }

    // Start the game
    public void StartGame()
    {
        StartCoroutine(waitAndLoad(2.0F));
    }

    public void Replay()
    {
        if (GameManager.instance == null)
        {
            Debug.LogError("No se encontró una instancia de GameManager para reiniciar la partida.");
            return;
        }

        GameManager.instance.Reset();
    }
}