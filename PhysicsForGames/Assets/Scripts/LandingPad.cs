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
            if (dummyPart.IsSleeping())
                score.RecordScore(value);
        }
    }

    public void ClearLaunchPads()
    {
        dummyPartsOnPad.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dummy")
        {
            if (other.GetComponent<Rigidbody>())
            {
                dummyPartsOnPad.Add(other.GetComponent<Rigidbody>());
            }
        }
    }
}
