using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = $"Score: {score}";
    }
}
