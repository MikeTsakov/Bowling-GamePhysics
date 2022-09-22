using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InputController : MonoBehaviour {
    public BallCollider bc;
    public Rigidbody rb;
    public float movementForce;
    public float jumpForce;
    private Vector3 spawnPoint;
    public InputField massInputField;
    public InputField forceInputField;
    public InputField jumpInputField;
    public InputField bouncinessInputField;
    public InputField impactVelocityInputField;
    private bool respawn = false;
    // Use this for initialization
    void Start () {
        massInputField.text = rb.mass.ToString();
        forceInputField.text = movementForce.ToString();
        jumpInputField.text = jumpForce.ToString();
        bouncinessInputField.text = bc.dampCoefficient.ToString();
        impactVelocityInputField.text = bc.hitVelocityImpulse.ToString();
        spawnPoint = rb.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (Input.GetKey(KeyCode.S)) {
            rb.AddForce(Vector3.back * movementForce * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.W)) {
            rb.AddForce(Vector3.forward * movementForce * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.A)) {
            rb.AddForce(Vector3.left * movementForce * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.D)) {
            rb.AddForce(Vector3.right * movementForce * Time.fixedDeltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector3.up * jumpForce);
        }
        if (respawn) {
            rb.velocity = new Vector3(0, 0, 0);
            rb.position = spawnPoint;
            respawn = false;
        }
	}

    public void RespawnBall() {
        respawn = true;
    }

    public void UpdateMassFromInputField() {
        rb.mass = float.Parse(massInputField.text);
    }
    public void UpdateForceFromInputField() {
        movementForce = float.Parse(forceInputField.text);
    }
    public void UpdateJumpForceFromInputField() {
        jumpForce = float.Parse(jumpInputField.text);
    }
    public void UpdateBouncinessFromInputField() {
        bc.dampCoefficient = float.Parse(bouncinessInputField.text);
    }
    public void UpdateImpactVelocityInputField() {
        bc.hitVelocityImpulse = float.Parse(bouncinessInputField.text);
    }
}
