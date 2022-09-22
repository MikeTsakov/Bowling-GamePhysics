using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollider : MonoBehaviour {

    public float dampCoefficient;
    public Rigidbody rb;
    public Vector3 lastVelocity;
    public float hitVelocityImpulse;
    private Vector3 impulse;
    private bool applyImpulse;

	// Use this for initialization
	void Start () {
        rb.maxAngularVelocity= float.PositiveInfinity;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (applyImpulse) {
            //Debug.Log("velocity before " + rb.velocity);
            rb.velocity = lastVelocity + impulse + impulse * dampCoefficient;
            //Debug.Log("n " + n + " dn " + dn + " impulse " + impulse + " velocity after " + rb.velocity);
            applyImpulse = false;
        }
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.rigidbody == null) {
            applyImpulse = true;
            for(int i = 0; i < collision.contacts.Length; i++) {
                Vector3 n = collision.contacts[i].normal;
                impulse = -n * Vector3.Dot(lastVelocity, n);
            }
        }

        Stretcher s = collision.transform.gameObject.GetComponent<Stretcher>();
        if (s != null) {
            s.AddVelocity(hitVelocityImpulse);
        }
    }
}
