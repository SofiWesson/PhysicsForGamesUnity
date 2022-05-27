using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject explosionRadius;

    public float explosionTimer = 0f;
    public float explosionDelay = 0f;

    public float force = 0f;

    [SerializeField]
    List<Rigidbody> objectsInRadius = new List<Rigidbody>();

    // Start is called before the first frame update
    void Awake()
    {
        Camera cam = FindObjectOfType<Camera>();
        Transform tCam = cam.transform;

        explosionTimer = 3;
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 push = tCam.forward * 150 + Vector3.up * 50;
        rb.AddRelativeForce(push);

        explosionRadius.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        explosionTimer -= Time.deltaTime;

        foreach (Rigidbody obj in objectsInRadius)
        {
            if (obj == null)
                objectsInRadius.Remove(obj);
        }

        if (explosionTimer < 0)
        {
            foreach (Rigidbody obj in objectsInRadius)
            {
                SphereCollider exploisionRadiusCollider = explosionRadius.GetComponent<SphereCollider>();

                obj.AddExplosionForce(force, this.transform.position, exploisionRadiusCollider.radius);
            }

            explosionDelay -= Time.deltaTime;
            if (explosionTimer < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb == null)
            rb = HasParent(other);

        if (rb != null)
        {
            rb = HasParent(rb);
            if (rb != null)
                if (!objectsInRadius.Contains(rb))
                    objectsInRadius.Add(rb);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if (rb == null)
            rb = HasParent(other);

        if (rb != null)
        {
            rb = HasParent(rb);
            if (objectsInRadius.Contains(rb))
                objectsInRadius.Remove(rb);
        }
    }

    Rigidbody HasParent(Rigidbody a_rb)
    {
        Rigidbody rb = a_rb;

        if (rb.transform.parent != null)
        {
            Transform t = rb.transform.root;
            if (t.GetComponent<Rigidbody>() != null)
                rb = t.GetComponent<Rigidbody>();
        }

        return rb;
    }

    Rigidbody HasParent(Collider a_collider)
    {
        Rigidbody rb = null;

        if (a_collider.transform.parent != null)
        {
            Transform t = a_collider.transform.root;
            if (t.GetComponent<Rigidbody>() != null)
                rb = t.GetComponent<Rigidbody>();
        }

        return rb;
    }

    Rigidbody HasParent(Collision a_collision)
    {
        Rigidbody rb = null;

        if (a_collision.transform.parent != null)
        {
            Transform t = a_collision.transform.root;
            if (t.GetComponent<Rigidbody>() != null)
                rb = t.GetComponent<Rigidbody>();
        }

        return rb;
    }
}
