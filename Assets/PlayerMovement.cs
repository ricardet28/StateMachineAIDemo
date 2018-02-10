using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speedMovement = 5f;
    public float speedRotation = 5f;

    Rigidbody rb;
    PlayerInput _playerInput;
    int floorMask;
    float camRayLength = 100f;

    private void Awake()
    {

        floorMask = LayerMask.GetMask("Floor");
        rb = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move(_playerInput.CaptureAxisMovement());
        Rotate(_playerInput.CaptureMouseInput());
	}

    void Move(Vector3 value)
    {
        rb.MovePosition(transform.position + value * speedMovement * Time.deltaTime);
    }
    void Rotate(Vector3 value)
    {
        Ray camRay = Camera.main.ScreenPointToRay(value);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse.normalized);
            rb.MoveRotation(newRotation);
        }
        
    }
    
}
