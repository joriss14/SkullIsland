using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_control : MonoBehaviour
{


    [Header("Firing Settings")]
    public GameObject cannonball;  // Reference to the cannonball prefab
  
    public Transform firepoint;  // Position where the cannonball is spawned (usually the barrel tip)
    public Transform end;
    public float fireForce = 0.01f;  // The force with which the cannonball is fired
    public Rigidbody ball_physics;  


    private void Start()
    {
       // cannonball.SetActive(false);
    }

    private void Update()
    {

        // Fire the cannonball when Space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireCannonball();
        }

    }



    void FireCannonball()
    {
        Vector3 pointA = firepoint.position;
        Vector3 pointB = end.position;

        float t = 0.01f; // t is a value between 0 and 1
        Vector3 vectorAB = Vector3.Lerp(pointA, pointB, t);



        //// Get the Rigidbody component of the cannonball and apply force to it
        Rigidbody rb = cannonball.GetComponent<Rigidbody>();


        // Get control of the physics of the ball and connect it to 'Ball_physics'. 
        // Ball_physics = move_ball.gameObject.GetComponent<Rigidbody>();
        // Turn off the physics of the ball so we don’t upset the physics engine by just
        // moving the ball. 
        ball_physics.isKinematic = true;
        // Move the ball to the location of the SpawnPoint object. 
        cannonball.transform.position = firepoint.transform.position;
        // Reset the physics of the ball now we have moved it. 
        ball_physics.isKinematic = false;

        cannonball.SetActive(true);




        rb.AddForce(vectorAB * fireForce);



        // Ensure we have a cannonball prefab assigned in the inspector
        // Instantiate the cannonball at the fire point position and rotation
        //cannonball.SetActive(false);





    }
}