﻿using UnityEngine;
using System.Collections;

public class HeroCheck : MonoBehaviour {

    public bool hero1;
    public bool hero2;
    public bool hero3;


	// Use this for initialization
	void Start ()
    {
	

	}
	

    public void BuyHero1()
    {
        //add function to subtract gold
        hero1 = true;
    }

    public void BuyHero2()
    {
        //add function to subtract gold
        hero2 = true;
    }

    public void BuyHero3()
    {
        //add function to subtract gold
        hero3 = true;
    }

    // Update is called once per frame
    void Update ()
    {
	
	}
}
