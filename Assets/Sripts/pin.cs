using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pin : MonoBehaviour {

    // Use this for initialization
    //private Rigidbody rigidbody;
    //private bool collisionDetect;
    //public GameObject ball;
    //Vector3 ballPosition;
    //private int stPinov;
    //private int vsiPini;

    //private GM gm;
    public static int pins;
    private static Vector3 pinG; 
    
    

	void Start () {
        //rigidbody = GetComponent<Rigidbody>();
        //collisionDetect = false;
        //vsiPini = 10;
        //stPinov = 0;
        pinG = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        //ballPosition = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);
        pins += 1;
    }

    // Update is called once per frame
    void Update() {
        if (this.transform.localEulerAngles.x == 250f || this.transform.localEulerAngles.x == 300f)
        {
            pins--;
        }
        
    }

}
