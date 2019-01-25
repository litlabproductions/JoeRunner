using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uIManager : MonoBehaviour {

    public Text scoreText;
    public Text hiScoreText;

    public float scoreCount;
    public float hiScoreCount;

    public float pointerPerSecond;

    public bool scoreIncreasing;

    public bool shouldDouble;

	// Use this for initialization
	void Start ()
    {
        // Apply previous high score.

        if (PlayerPrefs.HasKey("HighScore"))
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
		
	}
	
	// Update is called once per frame
	void Update ()
    {       // A
        if (scoreIncreasing)
            scoreCount += pointerPerSecond * Time.deltaTime;

        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);// ~ Save score for player.
        }
        scoreText.text = "Score: " + Mathf.Round(scoreCount);   // ~ Literally scoreText->textbox.
        hiScoreText.text = "High Score: " + Mathf.Round(hiScoreCount);


	}

    public void AddScore(int pointsToAdd)
    {
        if (shouldDouble)
        {
            pointsToAdd = pointsToAdd * 2;
        }
        scoreCount += pointsToAdd;
    }

}
