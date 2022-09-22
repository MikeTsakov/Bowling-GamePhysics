using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stretcher : MonoBehaviour {

    public float timestep;
    public Transform tr;
    public float K;
    public float stretchFactor;
    private float vy = 0; // the force along the Y axis (objects stretch vertically with a fixed bottom
    private float d = 0;
    private float deltatimeCounter;

    private Vector3 initialScale; // rest displacement in world coordinates

    // Use this for initialization
    void Start() {
        initialScale = tr.localScale;
    }

    public void AddVelocity(float v) {
        vy += v;
    }

    private void Update() {
        deltatimeCounter += Time.deltaTime;
        if (deltatimeCounter > timestep) {
            deltatimeCounter -= timestep;
            float springForce = -K * d; // force towards rest state - Hooke's Law
            vy = vy + springForce * timestep;
            d = d + vy * timestep;
            float finalY = initialScale.y + d * stretchFactor;
            if (finalY < initialScale.y) {
                finalY = initialScale.y;
                d = 0; vy = 0;
            }
            //Debug.Log("s " + springForce + " vy " + vy + " d " + d + " ls " + tr.localScale + " is " + initialScale);
            tr.localScale = new Vector3(initialScale.x, finalY, initialScale.z);
        }
    }
}
