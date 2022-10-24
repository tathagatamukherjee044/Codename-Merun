using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private float gravity;
    [SerializeField] private float jumpVelocity = 2.0f;
    [SerializeField] private GameObject playerController;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private Vector2 velocity;
    [SerializeField] private float groundheight;
    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //transform.position+=Vector3.right*speed*Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                isGrounded = false;
                velocity.y = jumpVelocity;
            }
            
        }

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (isGrounded)
            {
                isGrounded = false;
                velocity.y = jumpVelocity;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("OBSTACLE"))
        {
            Debug.Log("collided player is dead");
            Time.timeScale = 0.25f;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TRAIN"))
        {
            isGrounded = true;
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        //rigidbody2D.velocity = Vector2.up * jump;
        if (!isGrounded)
        {
            

            pos.y += velocity.y * Time.fixedDeltaTime;
            velocity.y += gravity * Time.fixedDeltaTime;
            isGrounded = false;
            
        }
        transform.position = pos;
    }

}
