using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosHandler : MonoBehaviour
{
    Camera cam = null;
    Rigidbody player = null;

    Transform FPS = null;
    Transform TPS = null;

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
        cam = GetComponentInChildren<Camera>();
        player = GetComponent<Rigidbody>();

        if (player != null)
        {
            FPS = player.GetComponentInChildren<Transform>().Find("FPSCamPos");
            TPS = player.GetComponentInChildren<Transform>().Find("TPSCamPos");
        }
        
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
        // ================================================ REMOVE ================================================
        if (test)
        {
            test = false;
            if (cam.transform.position == FPS.position)
                cam.transform.position = TPS.position;
            else
                cam.transform.position = FPS.position;
        }
        // ========================================================================================================
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
