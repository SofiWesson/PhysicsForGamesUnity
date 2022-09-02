using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreakingBallDummyCollision : MonoBehaviour
{
    public Score score;

    private void OnTriggerEnter(Collider other)
    {
        // checks for the dummy's root
        if (other.gameObject.layer == 6)
        {
            // turns on dummy's ragdoll
            Ragdoll ragdoll = other.transform.GetChild(0).GetComponent<Ragdoll>();
            ragdoll.RagdollOn = true;
        }
    }
}