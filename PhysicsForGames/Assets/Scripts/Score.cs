using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;

    Rigidbody dummyHips;
    Vector2 dummyStartPos = Vector2.zero;

    float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "score " + score.ToString();
    }

    public void RecordScore(int score)
    {
        if (score > this.score)
            this.score = score;
        scoreText.text = "score " + this.score.ToString();
    }

    public void SetStartPos(Vector2 startPos) { dummyStartPos = startPos; }
    public void SetHips(Rigidbody hips) { dummyHips = hips; }
}
