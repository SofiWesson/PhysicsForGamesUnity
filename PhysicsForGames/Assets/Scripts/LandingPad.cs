using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingPad : MonoBehaviour
{
    public int value = 0;
    public Score score;

    List<Rigidbody> dummyPartsOnPad = new List<Rigidbody>();

    private void Update()
    {
        foreach (Rigidbody dummyPart in dummyPartsOnPad)
        {
            // check if dummy parts on pad are moving
            if (dummyPart.IsSleeping())
                score.RecordScore(value); // update score
        }
    }

    public void ClearLaunchPads()
    {
        dummyPartsOnPad.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dummy") // check for if dummy is on pad
        {
            if (other.GetComponent<Rigidbody>())
            {
                // add dummy parts to list
                dummyPartsOnPad.Add(other.GetComponent<Rigidbody>());
            }
        }
    }
}
