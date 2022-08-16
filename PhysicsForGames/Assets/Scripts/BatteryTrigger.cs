using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryTrigger : MonoBehaviour
{
    public Rigidbody wreakingBall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Battery")
        {
            wreakingBall.isKinematic = false;
        }
    }
}
