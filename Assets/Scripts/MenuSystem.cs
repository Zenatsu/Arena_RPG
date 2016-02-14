using UnityEngine;
using System.Collections;

public class MenuSystem : MonoBehaviour {

    //this class isnt fully functional yet

    public GameObject radialMenuFade;
    public Animator RadialMenu;
    bool clicked = false;


    public void RadialMenuCall()
    {
        clicked = !clicked;
        print("Clciked is: " + clicked);
        if (clicked == true)
        {
            //enable the animator component
            RadialMenu.enabled = true;
            //play the Slidein animation
            RadialMenu.Play("RadialMenu");
        }

        if(clicked == false)
        {
            //enable the animator component
            RadialMenu.enabled = true;
            //play the Slidein animation
            RadialMenu.Play("RadialMenuFadeOut");
        }
        
    }

	// Use this for initialization
	void Start ()
    {
        
        //get the animator component
        RadialMenu = RadialMenu.GetComponent<Animator>();
        //disable it on start to stop it from playing the default animation
        RadialMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
