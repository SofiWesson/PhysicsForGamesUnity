using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // quit the application
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
    }
}
