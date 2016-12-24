using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateBuyButton : MonoBehaviour {

    GameObject control;

    public Texture btnTexture;

    GUIStyle style;

	// Use this for initialization
	void Start ()
    {
        control = GameObject.Find("GameController");

    }
	
    void OnGUI()
    {
        if (GUI.Button(new Rect(460, 310, 160, 30), "Buy Hero 1"))
            control.GetComponent<HeroCheck>().BuyHero1();
        if (GUI.Button(new Rect(840, 310, 160, 30), "Buy Hero 2"))
            control.GetComponent<HeroCheck>().BuyHero2();
    }

	// Update is called once per frame
	void Update () {
	
	}
}
