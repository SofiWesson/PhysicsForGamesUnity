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

    // Start is called before the first frame update
    void Start()
    {
        batteryResetPos = battery.position;
        battertResetRot = battery.rotation;
        
        foreach (Transform t in wreakingball)
        {
            wreakingballResetPos.Add(t.position);
            wreakingballResetRot.Add(t.rotation);
        }
        
        dummyResetPos = dummy.position;
        dummyResetRot = dummy.rotation;
        Transform hips = dummy.GetChild(0).GetChild(1);
        Rigidbody hipsRB = hips.GetComponent<Rigidbody>();
        score.SetHips(hipsRB);
    }

    public void ResetWreakingball()
    {
        battery.position = batteryResetPos;
        battery.rotation = battertResetRot;
        battery.gameObject.SetActive(true);
        battery.GetComponent<Rigidbody>().isKinematic = false;

        wreakingball.GetChild(wreakingball.childCount - 1).GetComponent<Rigidbody>().isKinematic = true;
        for (int i = 0; i < wreakingball.childCount; i++)
        {
            Transform child = wreakingball.GetChild(i);
            child.position = wreakingballResetPos[i];
            child.rotation = wreakingballResetRot[i];
        }

        Destroy(dummy.gameObject);
        dummy = Instantiate(dummyPrefab, dummyResetPos, dummyResetRot).transform;
        score.SetStartPos(new Vector2(dummy.position.x, dummy.position.z));
        Transform hips = dummy.GetChild(0).GetChild(1);
        Rigidbody hipsRB = hips.GetComponent<Rigidbody>();
        score.SetHips(hipsRB);
    }
}
