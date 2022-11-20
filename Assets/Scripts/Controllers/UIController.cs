using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    public UIView uiView;
    // Start is called before the first frame update
    void Start()
    {
        //Component UIView = canvas.GetComponent<UIView>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void deathScreenOn()
    {
        canvas.GetComponent<UIView>().deathScreenOn();
    }

    public void pointsIncrement()
    {
        uiView.pointsIncrement();
    }
}


