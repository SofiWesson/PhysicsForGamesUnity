using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletHole;
    public ParticleSystem muzzleFlash;

    GameObject gb;

    Raycaster raycaster;
    Ray ray;
    RaycastHit hit;

    Transform[] children;

    private void Start()
    {
        raycaster = FindObjectOfType<Raycaster>();

       children = new Transform[transform.childCount];
        int i = 0;
        foreach (Transform T in transform)
            children[i++] = T;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = raycaster.GetRay();
            hit = raycaster.GetHit();
            gb = raycaster.GetObjectHit();

            if (gb == null)
                return;

            if (gb.name != "Explosion_Radius")
            {
                Quaternion rotation = new Quaternion(0, 0, 0, 0);
                GameObject hole = Instantiate(bulletHole, hit.point, rotation);
                
                hole.transform.parent = gb.transform;

                hole.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation, 360);
                hole.transform.localPosition += hit.normal / 10000;

                // muzzleFlash.Stop(true);
                // muzzleFlash.Play(true);

                Rigidbody rb = null;
                rb = hit.transform.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce(ray.direction * 100.0f);
                }
            }
        }
    }
}
