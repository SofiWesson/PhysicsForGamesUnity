using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public Transform battery;
    Vector3 batteryResetPos = Vector3.zero;
    Quaternion battertResetRot = Quaternion.identity;

    public Transform wreakingball;
    List<Vector3> wreakingballResetPos = new List<Vector3>();
    List<Quaternion> wreakingballResetRot = new List<Quaternion>();

    public Transform dummy;
    public GameObject dummyPrefab;
    Vector3 dummyResetPos = Vector3.zero;
    Quaternion dummyResetRot = Quaternion.identity;

    public Score score;

    public List<LandingPad> launchPads;
    public List<Rigidbody> greyBoxes;
    List<Vector3> greyBoxPositions = new List<Vector3>();
    List<Quaternion> greyBoxRotations = new List<Quaternion>();

    // Start is called before the first frame update
    void Start()
    {
        // store the battery's inital position and rotation
        batteryResetPos = battery.position;
        battertResetRot = battery.rotation;

        // store the dummy's inital position and rotation
        dummyResetPos = dummy.position;
        dummyResetRot = dummy.rotation;

        // store the initial position and rotation of all the parts of the wreaking ball
        foreach (Transform t in wreakingball)
        {
            wreakingballResetPos.Add(t.position);
            wreakingballResetRot.Add(t.rotation);
        }

        // store the inital position and rotation of all the boxes
        foreach (Rigidbody box in greyBoxes)
        {
            greyBoxPositions.Add(box.position);
            greyBoxRotations.Add(box.rotation);
        }
    }

    public void ResetScene()
    {
        // reset the battery
        battery.position = batteryResetPos;
        battery.rotation = battertResetRot;
        battery.gameObject.SetActive(true);
        battery.GetComponent<Rigidbody>().isKinematic = false;

        // reset all the boxes
        for (int i = 0; i < greyBoxes.Count; i++)
        {
            greyBoxes[i].gameObject.SetActive(true);
            greyBoxes[i].isKinematic = false;
            greyBoxes[i].position = greyBoxPositions[i];
            greyBoxes[i].rotation = greyBoxRotations[i];
        }

        wreakingball.GetChild(wreakingball.childCount - 1).GetComponent<Rigidbody>().isKinematic = true; // stop all physics interactions of the wreaking ball
        // reset all the parts of the wreaking ball
        for (int i = 0; i < wreakingball.childCount; i++)
        {
            Transform child = wreakingball.GetChild(i);
            child.position = wreakingballResetPos[i];
            child.rotation = wreakingballResetRot[i];
        }

        // clear the launch pads
        foreach (LandingPad pad in launchPads)
        {
            pad.ClearLaunchPads();
        }

        // reset the dummy
        Destroy(dummy.gameObject);
        dummy = Instantiate(dummyPrefab, dummyResetPos, dummyResetRot).transform;
    }
}
