using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycaster : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    public Ray GetRay() { return ray; }
    public RaycastHit GetHit() { return hit; }
    public GameObject GetObjectHit()
    { 
        if (hit.transform != null)
            return hit.transform.gameObject;
        else
            return null;
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out hit, 500, 9);
    }
}