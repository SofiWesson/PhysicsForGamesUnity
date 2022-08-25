using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreakingBallDummyCollision : MonoBehaviour
{
    public Score score;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Ragdoll ragdoll = other.transform.GetChild(0).GetComponent<Ragdoll>();
            ragdoll.RagdollOn = true;
        }
    }
}