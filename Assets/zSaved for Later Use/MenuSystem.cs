using UnityEngine;

public class MenuSystem : MonoBehaviour {

    //this class isnt fully functional yet

    public GameObject radialMenuFade;
    public Animator RadialMenu;
    public GameObject targetScript;
    public TargetSelection target;

    public void RadialMenuCall()
    {
        //enable the animator component
        RadialMenu.enabled = true;
        //play the Slidein animation
        RadialMenu.Play("RadialMenu");

        target.targeting = false;
    }

	// Use this for initialization
	void Start ()
    {
        target = targetScript.GetComponent<TargetSelection>();
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
