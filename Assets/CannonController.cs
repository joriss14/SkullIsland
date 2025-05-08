using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeed = 50f;

    [Header("Firing Settings")]
    public GameObject cannonballPrefab;  // Reference to the cannonball prefab
    public Transform firePoint;  // Position where the cannonball is spawned (usually the barrel tip)
    public float fireForce = 500f;  // The force with which the cannonball is fired

    //private Vector3 initialRotation;
    private Quaternion initialRotation;
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
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }

    void Update()
    {
        // Handle rotation with WASD keys
        float yaw = 0f;
        float pitch = 0f;

        if (Input.GetKey(KeyCode.A)) yaw = -1f;
        if (Input.GetKey(KeyCode.D)) yaw = 1f;
        if (Input.GetKey(KeyCode.W)) pitch = -1f;
        if (Input.GetKey(KeyCode.S)) pitch = 1f;

        Vector3 rotation = new Vector3(pitch, yaw, 0f) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation, Space.Self);

        // Fire the cannonball when Space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // FireCannonball();
        }
    }

    void FireCannonball()
    {
        // Ensure we have a cannonball prefab assigned in the inspector
        if (cannonballPrefab != null && firePoint != null)
        {
            // Instantiate the cannonball at the fire point position and rotation
            GameObject cannonball = Instantiate(cannonballPrefab, firePoint.position, firePoint.rotation);

            // Get the Rigidbody component of the cannonball and apply force to it
            Rigidbody rb = cannonball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(firePoint.forward * fireForce);
            }
        }
        else
        {
            Debug.LogError("Cannonball Prefab or FirePoint is not assigned!");
        }
    }
}
