using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Transform ballTransform;
    public InputController ic;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void LateUpdate () {
		if (ballTransform.position.y < -10) {
            ic.RespawnBall();
        }
	}
}
