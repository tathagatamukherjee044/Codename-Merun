using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainView : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    [SerializeField]
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;
        if (transform.position.x<=-10)
        {
            rigidbody2D.constraints = RigidbodyConstraints2D.None;
        }
    }

    // private void OnTriggerEnter2D(Collider2D collision) {
    //     if(collision.CompareTag("Player")){
    //         Debug.Log(this);
    //         Debug.Log(collision);
    //         collision.transform.SetParent(this.transform);
    //     }

    // }

    // private void OnTriggerExit2D(Collider2D collision) {
    //     if(collision.CompareTag("Player"))
    //     collision.transform.SetParent(null);
    // }
}
