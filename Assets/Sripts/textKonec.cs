using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textKonec : MonoBehaviour {

    private Text display;
    void Start()
    {
        display = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        display.text = "Število poizkusov: " + BallControl.stPonovitev.ToString();
    }
}
