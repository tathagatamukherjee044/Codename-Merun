using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainGeneratorView : MonoBehaviour
{
    public GameObject train;
    //public float pos = 7.5f;
    public GameObject previous;
    public HingeJoint2D hinge;
    public bool isEnterEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(train,new Vector3 (pos, 1, 0), Quaternion.identity);
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
            Instantiate(train, new Vector3(pos + 17.66f, 1.23f, 0), Quaternion.identity);
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
