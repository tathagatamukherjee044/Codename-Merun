using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainGeneratorView : MonoBehaviour
{
    public GameObject train;
    //public float pos = 7.5f;
    public GameObject previous;
    public HingeJoint2D hinge;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(train,new Vector3 (pos, 1, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerExit2D(Collider2D other) {
        //Debug.Log("train has left");
        float pos = other.gameObject.transform.position.x;
        Instantiate(train,new Vector3 (pos+17.6f, 1.36f, 0), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        hinge = other.gameObject.GetComponent<HingeJoint2D>();
        hinge.enabled = true;
        hinge.connectedBody = previous.GetComponent<Rigidbody2D>();
        previous = other.gameObject;
    }
}
