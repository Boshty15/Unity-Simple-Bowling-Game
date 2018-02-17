using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
    public GameObject ball;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = ball.transform.position - this.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if(ball.transform.position.z < 80)
            this.transform.position = ball.transform.position - offset;
	}
}
