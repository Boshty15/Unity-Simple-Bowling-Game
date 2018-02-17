using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tekst : MonoBehaviour {

    // Use this for initialization
    private Text display;
	void Start () {
        display = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {


        display.text = (10 - GM.padliKeglji).ToString();
	}
}
