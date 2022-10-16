using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float jump = 2.0f;
    [SerializeField] private GameObject playerController;
    [SerializeField] private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
       //rigidbody2D=gameObject.GetComponent<RigidBody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position+=Vector3.right*speed*Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            //jump in unity 2d?
            Debug.Log("jumped");
            rigidbody2D.velocity=Vector2.up * jump;



        }

    }

}
