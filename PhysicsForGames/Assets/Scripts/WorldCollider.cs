using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // checks for the player and teleports it back to the center of the map
        if (other.tag == "Player")
        {
            // the character controller needs to be temporarily disabled to change the players position
            other.GetComponent<CharacterController>().enabled = false;
            other.transform.position = Vector3.up;
            other.GetComponent<CharacterController>().enabled = true;
        }
        else if (other.tag == "PlayerPart") // ignores if a child object of the player touches the collider as the player is what needs to be teleported
            return;
        else
        {
            // stops all physics interaction of an object and disables it
            other.transform.root.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.root.gameObject.SetActive(false);
        }
    }
}
