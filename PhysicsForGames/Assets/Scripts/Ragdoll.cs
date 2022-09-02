using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Ragdoll : MonoBehaviour
{
    private Animator m_animator = null;
    public List<Rigidbody> m_rigidbodies = new List<Rigidbody>();

    CameraPosHandler cam;

    public bool RagdollOn
    {
        get { return !m_animator.enabled; }
        set
        {
            // enable / disable the animator
            m_animator.enabled = !value;
            foreach (Rigidbody rb in m_rigidbodies)
            {
                rb.isKinematic = !value;
            }
            if (tag != "Dummy")
            {
                if (value)
                    cam.ChangeCameraPos("TPS"); // change camera to third person camera if the players ragdoll is enabled
                else
                    cam.ChangeCameraPos("FPS"); // change camera to first person camera if the players ragdoll is disabled
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();

        // set all player rigidbodies to be kinematic
        foreach (Rigidbody rb in m_rigidbodies)
        {
            rb.isKinematic = true;
        }

        cam = GetComponent<CameraPosHandler>();
    }
}
