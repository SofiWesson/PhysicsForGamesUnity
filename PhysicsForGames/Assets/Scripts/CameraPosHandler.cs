using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosHandler : MonoBehaviour
{
    Camera cam = null;

    Transform FPS = null;
    Transform TPS = null;

    CharacterController player = null;

    float playerCapsuleRadius = 0.2f;

    // Only used to set initial camera postion
    public bool isFPSMode = true;

    public bool IsFPSMode
    {
        get { return isFPSMode; }
        set { isFPSMode = value; }
    }

    // REMOVE
    public bool test = false;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.root.GetComponent<CharacterController>();

        cam = GetComponentInChildren<Camera>();

        FPS = GetComponentInChildren<Transform>().Find("FPSCamPos");
        TPS = GetComponentInChildren<Transform>().Find("TPSCamPos");
        
        if (cam != null && FPS != null && TPS != null)
        {
            if (isFPSMode)
                cam.transform.position = FPS.position;
            else
                cam.transform.position = TPS.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // move camera between fps and tps depending on weather or not player is ragdolling or not
    public void ChangeCameraPos(string mode)
    {
        if (mode == "FPS")
        {
            isFPSMode = true;
            cam.transform.position = FPS.position;
        }
        else if (mode == "TPS")
        {
            isFPSMode = false;
            cam.transform.position = TPS.position;
        }
    }
}
