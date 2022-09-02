using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        // initialise score text
        scoreText.text = "score " + score.ToString();
    }

    public void RecordScore(int score)
    {
        // update score text
        if (score > this.score)
            this.score = score;
        scoreText.text = "score " + this.score.ToString();
    }
}
