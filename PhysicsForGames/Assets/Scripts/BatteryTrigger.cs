using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryTrigger : MonoBehaviour
{
    public Rigidbody wreakingBall;
    GameObject battery;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Battery")
        {
            wreakingBall.isKinematic = false;
            battery = other.gameObject;
            battery.SetActive(false);
            battery.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
