using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosHandler : MonoBehaviour
{
    Camera cam = null;

    Transform FPS = null;
    Transform TPS = null;

    CharacterController player = null;

    // Used to set initial camera postion
    public bool isFPSMode = true;

    // Start is called before the first frame update
    void Start()
    {
        // get players root
        player = transform.root.GetComponent<CharacterController>();

        cam = GetComponentInChildren<Camera>();

        // store camera transforms
        FPS = GetComponentInChildren<Transform>().Find("FPSCamPos");
        TPS = GetComponentInChildren<Transform>().Find("TPSCamPos");
        
        // set camera position
        if (cam != null && FPS != null && TPS != null)
        {
            if (isFPSMode)
                cam.transform.position = FPS.position;
            else
                cam.transform.position = TPS.position;
        }
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
