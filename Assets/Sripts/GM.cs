using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {

    // Use this for initialization
    public GameObject cube;

      private GameObject ball;
    public Rigidbody rigibody;

      public GameObject txtStPoskusov;

      Vector3 ballPosition;
    public static int padliKeglji = 0;
    public static int stPoizkusov = 0;
    private bool pomoc = false;

    public static int standingPin;
    private int pinHolder;
    List<Vector3> positionPins = new List<Vector3>(10);
    
    GameObject[] objects;

    public Text text;
    public Text texkPo;

    public Rigidbody[] r1;
    List<Rigidbody> ArrayList;
    
    bool konecIgre = true;

    void Start () {
        ball = GameObject.Find("ball");
        ballPosition = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);
        stPoizkusov = 0;

        text.GetComponent<Text>().enabled = false;
        texkPo.GetComponent<Text>().enabled = false;
        

        objects = GameObject.FindGameObjectsWithTag("Pin");
        r1 = Rigidbody.FindObjectsOfType<Rigidbody>();
        ArrayList = new List<Rigidbody>(r1);

        ArrayList.RemoveAt(2);
        
        for (int i = 0; i < 10; i++) 
        {
            positionPins.Add(new Vector3(objects[i].transform.position.x, objects[i].transform.position.y, objects[i].transform.position.z));
        }


        
        konecIgre = false;
        
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Cube")
        {
            pinHolder++;
            //pins.SetActive(false);
            ResetBall();
            padliKeglji++;
        }
    }

    // Update is called once per frame
    void Update() {
        if(ball.transform.position.z > 125f)
        {
            ResetBall();
        }
        if (!pomoc)
        {
            foreach (GameObject pins in GameObject.FindGameObjectsWithTag("Pin"))
            {
                if (pins.transform.localEulerAngles.x < 180f || pins.transform.localEulerAngles.x > 350f )
                {
                    pinHolder++;
                    pins.SetActive(false);
                    ResetBall();
                    padliKeglji++;

                }
            }
            standingPin = pinHolder;
            // Debug.Log(standingPin);
            stPoizkusov++;
            if (padliKeglji == 10)
            {
                Debug.Log("KONEC IGRE");
                pomoc = true;
                ResetPin();
                text.GetComponent<Text>().enabled = true;
                texkPo.GetComponent<Text>().enabled = true;
                BallControl.premikanje = true;
                konecIgre = true;
                //NewGame();
                
            }
            pinHolder = 0;
        }
        if (Input.GetKey(KeyCode.K))
        {
            foreach (GameObject o in objects)
            {
                o.SetActive(false);
            }
            Debug.Log("KONEC IGRE S TIPKO");
            pomoc = true;
            ResetPin();
            text.GetComponent<Text>().enabled = true;
            texkPo.GetComponent<Text>().enabled = true;
            BallControl.premikanje = true;
            konecIgre = true;
        }
        if (Input.GetKey(KeyCode.R))
        {
            NewGame();
            konecIgre = false;
           
            //button.onClick.AddListener(NewGame);
        }

    }
   public void ResetBall()
    {

        ball.transform.position = ballPosition;
        BallControl.premikanje = false;
        rigibody.velocity = Vector3.zero;
        rigibody.angularVelocity = Vector3.zero;
        ball.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
       // ButtonManager.canvas.SetActive(true);
        //Debug.Log(stPoskusov);
        // stPoskusov += 1;
    }
    private void ResetPin()
    {
        for (int i = 0; i < 10; i++)
        {
            objects[i].transform.rotation = Quaternion.Euler(new Vector3(-90f, 0f, 0f));
            objects[i].transform.position = positionPins[i];
            ArrayList[i].velocity = Vector3.zero;
            ArrayList[i].angularVelocity = Vector3.zero;
            objects[i].SetActive(true);
        }
    }
    void NewGame()
    {
        //Debug.Log("Nova igra");
        ResetPin();
        text.GetComponent<Text>().enabled = false;
        texkPo.GetComponent<Text>().enabled = false;
        stPoizkusov = 0;
        padliKeglji = 0;
        BallControl.premikanje = false;
        pomoc = false;
        BallControl.stPonovitev = 0;
    }
}
