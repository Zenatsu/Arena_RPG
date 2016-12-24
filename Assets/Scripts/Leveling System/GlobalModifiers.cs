using UnityEngine;
using System.Collections;

public class GlobalModifiers : MonoBehaviour {

    public GameObject player;
    public GameObject hero1;
    public GameObject hero2;
    public GameObject badguy;

    public int Str;
    public int Int;
    public int Dex;
    public int Spd;
    public int Con;

    public int attk;
    public int maxHP;
    public int currentHP;
    public float speed;

    public int gold;


    // Use this for initialization
    void Start ()
    {


        Str=1;
        Int=1;
        Dex=1;
        Spd=1;
        Con=1;

        attk=1;
        maxHP=1;
        currentHP=1;
        speed=1;
}
	

    // Update is called once per frame
	void Update ()
    {
	
	}
}
