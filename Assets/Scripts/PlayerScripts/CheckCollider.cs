using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "OBSTACLE")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Bitch Iam Alreadt Dead");
        }
    }
}
