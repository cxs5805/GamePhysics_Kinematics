using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorMovement : MonoBehaviour
{
    // Author: Chris Schiff
    // This script defines the behavior for the blue cube,
    // which moves based on Euler approximations of the
    // exact equations that define the movement of the
    // red cube.

    // NOTE: Both cubes have the same initial kinematic values.

    // attributes for kinematics properties
    // the object's Transform component already keeps track of position
    private Vector3 velocity;
    private Vector3 acceleration;
    
    // additional kinematic attributes
    // these are meant to be constant throughout the simulation
    private Vector3 positionInitial;
    private Vector3 velocityInitial;
    private Vector3 accelerationInitial;

    // simple counter to keep track of elapsed frames.
    // after 2 seconds, stop updating kinematics
    public int counter;
    private int frameStarted;

	// Use this for initialization
	void Start ()
    {
        // set initial kinematic values
        positionInitial = new Vector3(0.0f, 0.0f, transform.position.z);
        velocityInitial = new Vector3(0.7f, 10.0f);
        accelerationInitial = new Vector3(0.0f, -9.8f);

        Init();
	}
	
    public void Init()
    {        
        // set the actor's actual kinematic attributes to the starter values
        transform.position = positionInitial;
        velocity = velocityInitial;
        acceleration = accelerationInitial;

        // start the counter and the frame reference
        counter = 0;
        frameStarted = Time.frameCount;
    }

    // Update is called once per frame
    void Update ()
    {
        // increment counter
        //counter++;
        //counter = Time.frameCount;
        counter = Time.frameCount - frameStarted;

        // only use Euler for 2 seconds
        if (counter <= 120)
        {
            velocity += acceleration * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
        }
    }
}
