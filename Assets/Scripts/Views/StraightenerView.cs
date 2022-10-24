using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightenerView : MonoBehaviour
{

    public Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TRAIN"))
        {
            rigidbody2D  = collision.GetComponent<Rigidbody2D>();
            rigidbody2D.constraints = RigidbodyConstraints2D.None;

        }
    }
}
