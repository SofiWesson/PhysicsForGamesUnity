using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletHole;
    public ParticleSystem muzzleFlash;
    public Reset reset;

    GameObject gb;

    Raycaster raycaster;
    Ray ray;
    RaycastHit hit;

    private void Start()
    {
        raycaster = FindObjectOfType<Raycaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // cast ray from gun
            ray = raycaster.GetRay();
            hit = raycaster.GetHit();
            gb = raycaster.GetObjectHit();

            if (gb == null)
                return;

            if (gb.name != "Explosion_Radius") // ignore if shooting the grenades explosion radius
            {
                // reset the scene if the reset button is pressed
                if (gb.tag == "Reset")
                {
                    reset.ResetScene();
                    return;
                }

                // add bullet hole to position shot
                GameObject hole = Instantiate(bulletHole, hit.point, Quaternion.identity);
                hole.transform.parent = gb.transform;
                hole.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation, 360);
                hole.transform.localPosition += hit.normal / 10000; // place bullet hole on surface of object

                Rigidbody rb = null;
                rb = hit.transform.GetComponent<Rigidbody>();

                // if wreaking ball is shot add force to wreaking ball
                if (gb.tag == "Wreakingball")
                    rb.AddForce(ray.direction * 1000.0f);

                // add force to any rigidbody
                if (rb != null)
                    rb.AddForce(ray.direction * 100.0f);
            }
        }
    }
}
