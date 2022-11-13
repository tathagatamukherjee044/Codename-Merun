using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LayerMask platformLayermask;
    private Component scriptParent;
    public bool isGrounded;

    private void Start()
    {
        //scriptParent = this.transform.parent.GetComponent<PlayerView>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        isGrounded = collider != null;
        this.transform.parent.GetComponent<PlayerView>().ToggleGrounded(true);
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
        this.transform.parent.GetComponent<PlayerView>().ToggleGrounded(false);
    }
}
