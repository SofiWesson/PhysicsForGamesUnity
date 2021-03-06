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
            m_animator.enabled = !value;
            foreach (Rigidbody rb in m_rigidbodies)
            {
                rb.isKinematic = !value;
            }
            if (!value)
                cam.ChangeCameraPos("FPS");
            else
                cam.ChangeCameraPos("TPS");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();

        foreach (Rigidbody rb in m_rigidbodies)
        {
            rb.isKinematic = true;
        }

        cam = GetComponent<CameraPosHandler>();
    }
}
