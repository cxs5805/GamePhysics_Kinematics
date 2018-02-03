using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Author: Chris Schiff
    // This script defines the behavior for the UI
    // components of the scene. First, it updates
    // the display text for the final positions for
    // both cubes. Second, it provides access for the
    // UI buttons to restart the simulation for the
    // red cube, the blue cube, or both cubes.

    // UI Elements displaying final positions
    public Text redFinal;
    public Text blueFinal;

    // Red and Blue cubes and their associated attributes
    public GameObject redCube;
    public GameObject blueCube;
    private EquationMovement equationMovement;
    private ActorMovement actorMovement;

    // flags to keep track of state of simulation
    private bool redFinished;
    private bool blueFinished;

	// Use this for initialization
	void Start ()
    {
        // fetch movement scripts from red and blue cubes
        equationMovement = redCube.GetComponent<EquationMovement>();
        actorMovement = blueCube.GetComponent<ActorMovement>();

        Init();
	}
	
    public void Init()
    {
        // by default, neither simulation has finished
        InitRed();
        InitBlue();
    }

    // reset script, flag, and text box for red simulation
    public void InitRed()
    {
        equationMovement.Init();
        redFinished = false;
        redFinal.text = "Red Cube's final pos\n(?, ?)";
    }

    // like InitRed, but for blue simulation
    public void InitBlue()
    {
        actorMovement.Init();
        blueFinished = false;
        blueFinal.text = "Blue Cube's final pos\n(?, ?)";
    }

	// Update is called once per frame
	void Update ()
    {
        // check counters in both scripts
        int redCounter = equationMovement.counter;
        int blueCounter = actorMovement.counter;

        // if red cube simulation has finished, update text box
        if (redCounter == 121 && !redFinished)
        {
            redFinal.text =
                "Red Cube's final pos\n" +
                "(" + redCube.transform.position.x + ", " + redCube.transform.position.y + ")";

            redFinished = true;
        }

        // do the same for the blue cube
        if (blueCounter == 121 && !blueFinished)
        {
            blueFinal.text = 
                "Blue Cube's final pos\n" + 
                "(" + blueCube.transform.position.x + ", " + blueCube.transform.position.y + ")";
            blueFinished = true;
        }
    }
}
