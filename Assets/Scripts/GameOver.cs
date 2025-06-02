using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{   
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    // Start is called before the first frame update
    void Start()
    {
        
        int finalScore = ScoreManager.score;
        score.text = "Puntuación: " + finalScore;

        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (finalScore > savedHighScore)
        {
            PlayerPrefs.SetInt("HighScore", finalScore);
            highScore.text = "ERES LA MÁS ALTA: " + finalScore;
        } else 
        {
            highScore.text = "Más alta: " + savedHighScore;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
