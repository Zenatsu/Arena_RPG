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
        if (GUI.Button(new Rect(120, 310, 160, 30), "Buy Hero 1"))
            control.GetComponent<HeroCheck>().BuyHero1();
        if (GUI.Button(new Rect(620, 310, 160, 30), "Buy Hero 2"))
            control.GetComponent<HeroCheck>().BuyHero2();
        if (GUI.Button(new Rect(1120, 310, 160, 30), "Buy Hero 3"))
            control.GetComponent<HeroCheck>().BuyHero3();
    }

	// Update is called once per frame
	void Update () {
	
	}
}
