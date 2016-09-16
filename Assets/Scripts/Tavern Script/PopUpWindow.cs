using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class PopUpWindow : MonoBehaviour {

    Vector3 mousePos;
    Rect window;
    bool showWindow;

    // Use this for initialization
    void Start()
    {
        
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //window = new Rect(Input.mousePosition.x, Input.mousePosition.y, 100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            showWindow = !showWindow;
        
    }

    void PopUp()
    {

    }

    void OnGUI()
    {
        

        if (showWindow)
            GUI.Box(new Rect(Input.mousePosition.x, -Input.mousePosition.y+652, 100, 100),"PopUpWindow");
    }


}
