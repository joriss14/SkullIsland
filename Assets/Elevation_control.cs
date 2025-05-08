using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevation_control : MonoBehaviour

{
    [Header("Rotation Settings")]
    public float rotationSpeed = 50f;

    [Header("Firing Settings")]
    public GameObject gun_barrel;  // Reference to the cannonball prefab



    //public Transform firePoint;  // Position where the cannonball is spawned (usually the barrel tip)
    //public float fireForce = 500f;  // The force with which the cannonball is fired

    private Vector3 Rotation;
    //private Quaternion initialRotation;
    private Vector3 initialPosition;

    void Awake()
    {
        //// Record the initial transform to maintain placement
        //initialPosition = transform.position;
        //initialRotation = transform.rotation;
    }

    void Start()
    {
        // Ensure cannon stays exactly where placed in the editor
        //transform.position = initialPosition;
        //transform.rotation = initialRotation;
    }

    void Update()
    {
        // Handle rotation with WASD keys
        float yaw = 0f;
        float pitch = 0f;

        //if (Input.GetKey(KeyCode.A)) yaw = -1f;
        //if (Input.GetKey(KeyCode.D)) yaw = 1f;
        if (Input.GetKey(KeyCode.W)) pitch = -1f;
        if (Input.GetKey(KeyCode.S)) pitch = 1f;

        Vector3 rotation = new Vector3(pitch, 0f, 0f) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation, Space.Self);
    }
}