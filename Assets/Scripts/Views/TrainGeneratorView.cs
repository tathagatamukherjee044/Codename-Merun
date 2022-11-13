using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainGeneratorView : MonoBehaviour
{
    public GameObject[] train;
    //public float pos = 7.5f;
    public GameObject previous;
    public HingeJoint2D hinge;
    public bool isEnterEnabled = false;
    public float nextPos = 32.79f;
    private int maxTrains;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(train,new Vector3 (pos, 1, 0), Quaternion.identity);
        float nextPos = train[0].GetComponent<TrainModel>().trainLength;
        GameObject train1 = Instantiate(train[0], new Vector3(1 + nextPos, 1.7f, 0), Quaternion.identity);
        hinge = train1.gameObject.GetComponent<HingeJoint2D>();
        hinge.enabled = true;
        hinge.connectedBody = previous.GetComponent<Rigidbody2D>();
        previous = train1.gameObject;
        GameObject train2 =  Instantiate(train[0], new Vector3(1 + nextPos*2, 1.7f, 0), Quaternion.identity);
        hinge = train2.gameObject.GetComponent<HingeJoint2D>();
        hinge.enabled = true;
        hinge.connectedBody = previous.GetComponent<Rigidbody2D>();
        previous = train2.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerExit2D(Collider2D collision) {
        Debug.Log("something has left");
        if (collision.gameObject.CompareTag("TRAIN"))
        {
            //isEnterEnabled = true;
            Debug.Log("train has left");

            float pos = collision.gameObject.transform.position.x;
            int temp = Random.Range(0, maxTrains);
            Instantiate(train[temp], new Vector3(pos + nextPos, 1.7f, 0), Quaternion.identity);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("something has entered");
        if (collision.gameObject.CompareTag("TRAIN"))
        {

            Debug.Log("train has entered");

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
