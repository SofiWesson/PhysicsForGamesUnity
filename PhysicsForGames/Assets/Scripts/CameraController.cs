using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float speed = 360f;
    public float distance = 6f;
    public float zoomSpeed = 2f;

    float currentDistance = 6f;
    float distanceBack = 6f;

    float heightOffset = 1.5f;

    public Vector3 angles;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // right drag rotates the camera
        angles = new Vector3(0, 0, 0);

        angles = transform.eulerAngles;
        float dx = Input.GetAxis("Mouse Y");
        float dy = Input.GetAxis("Mouse X");

        if (dx != 0)
        {
            // look up and down by rotating around x axis
            angles.x = Mathf.Clamp(angles.x + -dx * speed * Time.deltaTime, 0, 70);
            transform.eulerAngles = angles;
        }
        if (dy != 0)
        {
            // spin the camera around
            angles.y += dy * speed * Time.deltaTime;
            transform.eulerAngles = angles;
        }

        distanceBack = Mathf.Clamp(distanceBack - Input.GetAxis("Mouse ScrollWheel") * zoomSpeed, 2, 10);

        RaycastHit hit;
        if (Physics.Raycast(GetTargetPosition(), -transform.forward, out hit, distance))
        {
            // snap the camera right into where the collision happened
            currentDistance = hit.distance;
        }
        else
        {
            // relax th camera back to the desired distance
            currentDistance = Mathf.MoveTowards(currentDistance, distance + distanceBack, Time.deltaTime);
        }

        // look at the target position
        transform.position = GetTargetPosition() - currentDistance * transform.forward;
    }

    Vector3 GetTargetPosition()
    {
        return target.position + heightOffset * Vector3.up;
    }
}