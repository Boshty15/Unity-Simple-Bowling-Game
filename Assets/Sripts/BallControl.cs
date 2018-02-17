using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {
    public float speed = 20f, pressTime = 0, downTime = 0, upTime = 0;

    public float countDown = 2.0f;
    // Use this for initialization
    private Rigidbody rigibody;
    public static int stPonovitev = 0;
    public static bool premikanje = false;
    void Start () {
        rigibody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!premikanje)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.transform.position.x > -13.85f)
                    transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (this.transform.position.x < 10.65f)
                    transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                rigibody.velocity = new Vector3(0f, 0f, 55f);
                premikanje = true;
                stPonovitev++;
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
