using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudManager : MonoBehaviour {

    public TMP_Text scoreLabel;

    void OnEnable()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ScoreChanged += OnScoreChanged;
        }
    }

    void OnDisable()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ScoreChanged -= OnScoreChanged;
        }
    }

    // Use this for initialization
    void Start()
    {
        Refresh();
    }

    // Show player stats in the HUD
    public void Refresh()
    {
        scoreLabel.text = "Score: " + GameManager.instance.score;
    }

    void OnScoreChanged(int score)
    {
        scoreLabel.text = "Score: " + score;
    }
}
