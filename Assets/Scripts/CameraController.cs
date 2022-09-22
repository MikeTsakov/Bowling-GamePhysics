using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    Vector3 posOffset;

	// Use this for initialization
	void Start () {
        posOffset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = target.position + posOffset;
	}
}
