using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private float gravity;
    [SerializeField] private float jumpVelocity = 2.0f;
    [SerializeField] private float moveVelocity = 10f;
    [SerializeField] private GameObject uiController;
    //[SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private Vector2 velocity;
    [SerializeField] private float groundheight;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask platformLayer;
    public bool isGrounded = false;
    public bool isBehind = false;
    private float speedMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        //float distToGround = collider.bounds.extents.y;
        boxCollider2D = this.GetComponent<BoxCollider2D>();

    }
    // Update is called once per frame
    void Update()
    {
        //transform.position+=Vector3.right*speed*Time.deltaTime;

        //isGrounded= transform.Find("GroundCheck").GetComponent<GroundCheck>( ).isGrounded;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                Debug.Log("jumped");
                isGrounded = false;
                velocity.y = jumpVelocity;
            }
            /*else
            {
                Debug.Log("dashed");
                CorrectPosition();
            }*/

        }

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (isGrounded)
            {
                //isGrounded = false;
                velocity.y = jumpVelocity;
            }
            else
            {
                Debug.Log("dashed");
                CorrectPosition();
            }
        }

       /* if (transform.position.x <= -6 && !isBehind)
        {
            isBehind = true;
            Debug.Log("Behind");
            CorrectPosition();
        }

        if (transform.position.x >= -4 && isBehind)
        {
            isBehind = false;
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("OBSTACLE"))
        {
            Debug.Log("collided player is dead");
            Time.timeScale = 0;
            uiController.GetComponent<UIController>().deathScreenOn();

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TRAIN"))
        {
            //isGrounded = true;
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

    public void CorrectPosition()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(moveVelocity, 0, 0);
    }

    public void ToggleGrounded(bool status)
    {
        isGrounded = status;
        Debug.Log(status);
    }

}
