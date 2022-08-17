using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;

    Rigidbody dummyHips;
    Vector2 dummyStartPos = Vector2.zero;

    bool launched = false;
    float record = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "record " + record.ToString() + " meters\n" + "score 0 meters";
    }

    private void Update()
    {
        if (launched)
        {
            if (dummyHips.IsSleeping())
                RecordDistance();
        }
    }

    void RecordDistance()
    {
        float distance = Vector2.Distance(dummyStartPos, dummyHips.position);
        launched = false;

        if (distance > record)
            record = distance;
        scoreText.text = "record " + record.ToString() + " meters\n" + "score " + distance.ToString() + " meters";
    }

    public bool GetLaunched() { return launched; }
    public void SetLaunched(bool state) { launched = state; }

    public void SetStartPos(Vector2 startPos) { dummyStartPos = startPos; }
    public void SetHips(Rigidbody hips) { dummyHips = hips; }
}
