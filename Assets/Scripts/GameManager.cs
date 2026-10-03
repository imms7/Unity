using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    // Static instance of the Game Manager,
    // can be access from anywhere
    public static GameManager instance = null;

    // Player score
    public int score = 0;
    public int CurrentScore => score;

    public int scoreToLoadLevel2 = 4; // Puntaje necesario para cargar el nivel 2

    public event Action<int> ScoreChanged;

    // High score
    public int highScore = 0;

    // Level, starting in level 1
    public int currentLevel = 1;

    // Highest level available in the game
    public int highestLevel = 2;

    // Called when the object is initialized
    void Awake()
    {
        // if it doesn't exist
        if(instance == null)
        {
            print("assigning GameManager instance");
            // Set the instance to the current object (this)
            instance = this;
        }

        // There can only be a single instance of the game manager
        else if(instance != this)
        {
            print("GameManager instance already exists");
            // Destroy the current object, so there is just one manager
            Destroy(gameObject);
            return;
        }

        // Don't destroy this object when loading scenes
        DontDestroyOnLoad(gameObject);
    }

    // Increase score
    public void IncreaseScore(int amount)
    {
        // Increase the score by the given amount
        score += amount;
        ScoreChanged?.Invoke(score);

        // Show the new score in the console
        print("New Score: " + score.ToString());

        if (score > highScore)
        {
            highScore = score;
            print("New high score: " + highScore);
        }

        if (currentLevel == 1 && score >= scoreToLoadLevel2)
        {
            if (!Application.CanStreamedLevelBeLoaded("Level2"))
            {
                Debug.LogError("No se puede cargar Level2. Agrégala a Build Settings o Build Profiles.");
                return;
            }

            currentLevel = 2;
            SceneManager.LoadScene("Level2");
        }
    }

    // Restart game. Refresh previous score and send back to level 1
    public void Reset()
    {
        // Reset the score
        score = 0;

        // Set the current level to 1
        currentLevel = 1;

        // Load corresponding scene (level 1 or "splash screen" scene)
        SceneManager.LoadScene("Level" + currentLevel);
    }

    public void RestartCurrentLevel()
    {
        score = 0;
        ScoreChanged?.Invoke(score);
        SceneManager.LoadScene("Level" + currentLevel);
    }

    public void LoadGameOver()
    {
        if (!Application.CanStreamedLevelBeLoaded("GameOver"))
        {
            Debug.LogError("No se puede cargar GameOver. Agrégala a Build Settings o Build Profiles.");
            return;
        }

        SceneManager.LoadScene("GameOver");
    }

    // Go to the next level
    public void IncreaseLevel()
    {
        if (currentLevel == 1 && score < scoreToLoadLevel2)
        {
            return;
        }

        if (currentLevel < highestLevel)
        {
            currentLevel++;            
        }
        else
        {
            currentLevel = 1;
        }
        SceneManager.LoadScene("Level" + currentLevel);
    }
}
