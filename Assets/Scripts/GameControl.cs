﻿using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

    public static GameControl control;

	// Use this for initialization
	void Start ()
    {
        
	}
	
    void Awake()
    {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
