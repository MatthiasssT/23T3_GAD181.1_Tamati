using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;
    public int scoreValue = 10;
    public TextMeshProUGUI scoreText;
    
    public void UpdateScore()
    {
        score += scoreValue;

        scoreText.text = "Score: " + score.ToString();
    }


}
