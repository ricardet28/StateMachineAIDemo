using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 CaptureAxisMovement()
    {
        Vector3 captureMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        return captureMovement;
    }

    public Vector3 CaptureMouseInput()
    {
        return Input.mousePosition;


    }
}
