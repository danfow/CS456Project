using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> objects;
    private int score;
    public TextMeshProUGUI scoreText;



    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);
        scoreText.text = "Score: " + score;
        


    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
