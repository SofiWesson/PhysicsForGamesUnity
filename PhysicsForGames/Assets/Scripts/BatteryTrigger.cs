using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryTrigger : MonoBehaviour
{
    public Rigidbody wreakingBall;
    GameObject battery;

    private void OnTriggerEnter(Collider other)
    {
        // checks if object on pad is a bettery
        if (other.tag == "Battery")
        {
            // released the wreaking ball
            wreakingBall.isKinematic = false;

            // disables the battery
            battery = other.gameObject;
            battery.SetActive(false);
            battery.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
