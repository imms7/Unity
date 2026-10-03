using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        if (GameManager.instance == null)
        {
            Debug.LogError("No se encontró una instancia de GameManager en GameOver.");
            return;
        }

        if (scoreText == null)
        {
            Debug.LogError("Asigna el campo Score Text de GameOverUI en el Inspector.");
            return;
        }

        scoreText.text = $"Puntaje obtenido: {GameManager.instance.CurrentScore}";
    }
}
