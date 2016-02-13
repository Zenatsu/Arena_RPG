using UnityEngine;
using System.Collections;

public class MenuSystem : MonoBehaviour {

    string[] buttons = new string[3] {
        "Start",
        "Options",
        "Exit"
    };
    
    int selected = 0;

	// Use this for initialization
	void Start ()
    {
        selected = 0;
	}

    int menuSelection(string[] buttonsArray, int selectedItem, string direction)
    {

        if (direction == "up")
        {
            if (selectedItem == 0)
            {

                selectedItem = buttonsArray.Length - 1;
            }
            else
            {
                selectedItem -= 1;

            }
        }

        if (direction == "down")
        {

            if (selectedItem == buttonsArray.Length - 1)
            {

                selectedItem = 0;
            }
            else
            {

                selectedItem += 1;
            }
        }

        return selectedItem;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            selected = menuSelection(buttons, selected, "up");
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            selected = menuSelection(buttons, selected, "udownp");
        }
    }

    void OnGUI()
    {
        GUI.SetNextControlName(buttons[0]);

        var selectColor = Color.green;

        if (GUI.Button(new Rect(0, 0, 100, 100), buttons[0]))
        {
            GUI.color = selectColor;
        }

        GUI.SetNextControlName(buttons[1]);
        if (GUI.Button(new Rect(0, 100, 100, 100), buttons[1]))
        {
            GUI.color = selectColor;
        }

        GUI.SetNextControlName(buttons[2]);
        if (GUI.Button(new Rect(0, 200, 100, 100), buttons[2]))
        {
            GUI.color = selectColor;
        }

        GUI.FocusControl(buttons[selected]);
    }

}
