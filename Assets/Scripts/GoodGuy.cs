﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoodGuy : MonoBehaviour {

    //base stats
    int bStr = 1;
    int bInt = 1;
    int bDex = 1;
    int bSpd = 1;
    int bCon = 1;

    //modified stats
    public int mStr;
    public int mInt;
    public int mDex;
    public int mSpd;
    public int mCon;
        

    public int attk;
    public int maxHP;
    public int currentHP;
    public float speed;
    public GameObject thisObject;

    public GameObject scriptManager;
    public CombatSys combatScript;

    public Animator playerAnimator;

    // Use this for initialization
    void Start()
    {
        thisObject = gameObject;
        maxHP = 10;
        speed = 50f;
        currentHP = maxHP;
        scriptManager = GameObject.Find("ScriptManager");
        combatScript = scriptManager.GetComponent<CombatSys>();

        playerAnimator = thisObject.GetComponent<Animator>();
        playerAnimator.enabled = false;
    }

    public void Clicked()
    {
        RadialMenuCall();   
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void RadialMenuCall()
    {
        //enable the animator component
        playerAnimator.enabled = true;
        //play the Slidein animation
        playerAnimator.Play("RadialMenu");
    }

    public void AttackAnimation()
    {
        playerAnimator.Play("RadialMenuFadeOut");
        playerAnimator.Play("GoodGuyAttack");
    }
}
