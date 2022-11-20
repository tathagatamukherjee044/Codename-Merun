using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainGeneratorView : MonoBehaviour
{
    public GameObject[] train;
    public GameObject coin;
    public GameObject firstCompartment;
    public int testOnlyNumber = 0;
    //public float pos = 7.5f;
    public GameObject previous;
    public HingeJoint2D hinge;
    public bool isEnterEnabled = false;
    private float nextPos;
    private int maxTrains;
    [SerializeField] private bool generartionEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        testOnlyNumber = StateMangerController.trainLength;
        //Instantiate(train,new Vector3 (pos, 1, 0), Quaternion.identity);
        GameObject train0 = Instantiate(train[testOnlyNumber], new Vector3(1.0f, 1.7f, 0), Quaternion.identity);
        previous = train0.gameObject;

        nextPos = train0.GetComponent<TrainModel>().trainLength;

        GameObject train1 = Instantiate(train[testOnlyNumber], new Vector3(1 + nextPos, 1.7f, 0), Quaternion.identity);
        hinge = train1.gameObject.GetComponent<HingeJoint2D>();
        hinge.enabled = true;
        hinge.connectedBody = previous.GetComponent<Rigidbody2D>();
        previous = train1.gameObject;

        GameObject train2 = Instantiate(train[testOnlyNumber], new Vector3(1 + nextPos * 2, 1.7f, 0), Quaternion.identity);
        hinge = train2.gameObject.GetComponent<HingeJoint2D>();
        hinge.enabled = true;
        hinge.connectedBody = train1.GetComponent<Rigidbody2D>();
        previous = train2.gameObject;

        

        this.transform.position = train2.transform.position;

        //Time.timeScale = 0;

        /* GameObject train0 = Instantiate(firstCompartment, new Vector3(1.0f, 1.7f, 0), Quaternion.identity);
         previous = train0.gameObject;*/

        //nextPos = firstCompartment.GetComponent<TrainModel>().trainLength;
        //Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        generartionEnabled = true;
    }

    
    private void OnTriggerExit2D(Collider2D collision) {
        //Debug.Log("something has left");
        if (collision.gameObject.CompareTag("TRAIN") )
        {
            //isEnterEnabled = true;
            //Debug.Log("train has left");


            float pos = collision.gameObject.transform.position.x;
            Debug.Log(pos);
            int temp = Random.Range(0, maxTrains);
            float collisionLength = train[testOnlyNumber].gameObject.GetComponent<TrainModel>().trainLength;
            float instantiatePos = nextPos / 2 + collisionLength/2;
            GameObject instatiatedTrain = Instantiate(train[testOnlyNumber], new Vector3(pos + instantiatePos, 1.7f, 0), Quaternion.identity);
            GameObject instantiatedCoin = Instantiate(coin, new Vector3(pos + instantiatePos, 1.7f, 0), Quaternion.identity);
            instantiatedCoin.transform.SetParent(instatiatedTrain.transform);
            nextPos = collisionLength;
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //Debug.Log("something has entered");
        if (collision.gameObject.CompareTag("TRAIN"))
        {

           // Debug.Log("train has entered");

            hinge = collision.gameObject.GetComponent<HingeJoint2D>();
            hinge.enabled = true;
            hinge.connectedBody = previous.GetComponent<Rigidbody2D>();
            previous = collision.gameObject;
            /*  hinge = previous.gameObject.GetComponent<HingeJoint2D>();
                  hinge.enabled = true;
                  hinge.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
                  previous = collision.gameObject;*/



        }
            
    }
}
