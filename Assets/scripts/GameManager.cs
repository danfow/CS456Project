using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> objects;
    private int score;
    private int lives;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI gameOver;
    public bool status = false;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);
        scoreText.text = "Score: " + score;
        lives = 5;
        lifeText.text = "Lives: " + lives;
        gameOver.text = "";

    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void UpdateLives(int lifeLost)
    {
        lives = lives + lifeLost;
        lifeText.text = "Lives: " + lives;
        if (lives == 0)
        {
            status = true;
            lifeText.text = "";
            scoreText.text = "";
            gameOver.text = "GAME OVER SUCKER";

        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
