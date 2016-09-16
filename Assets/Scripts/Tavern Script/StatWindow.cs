using UnityEngine;
using System.Collections;

public class StatWindow : MonoBehaviour {

    public GameObject control;
    GlobalStats global;
    // Use this for initialization
    void Start ()
    {
        global = control.GetComponent<GlobalStats>();
	}

    void OnGUI()
    {

        if (GUI.Button(new Rect(100, 20, 75, 20), "Skill Point"))
            global.skillPoint++;
        // Make a background box
        //               X   Y   W    H
        GUI.Box(new Rect(50, 50, 180, 250), "Stat window"); GUI.Label(new Rect(100, 70, 180, 250), "Skill Point: " + global.skillPoint);

        GUI.Label(new Rect(60, 98, 60, 25), "Strength"); GUI.Label(new Rect(60, 138, 70, 25), "Intelligence");
        GUI.Label(new Rect(60, 178, 60, 25), "Dexterity"); GUI.Label(new Rect(60, 218, 60, 25), "Speed");
        GUI.Label(new Rect(60, 258, 70, 25), "Consitution");
        if (global.skillPoint > 0)
        {
            if (GUI.Button(new Rect(140, 100, 20, 20), "+"))
            { global.mStr++; global.skillPoint--; }
            if (GUI.Button(new Rect(190, 100, 20, 20), "-"))
            { global.mStr--; global.skillPoint++; }
            if (GUI.Button(new Rect(140, 140, 20, 20), "+"))
            { global.mInt++; global.skillPoint--; }
            if (GUI.Button(new Rect(190, 140, 20, 20), "-"))
            { global.mInt--; global.skillPoint++; }
            if (GUI.Button(new Rect(140, 180, 20, 20), "+"))
            { global.mDex++; global.skillPoint--; }
            if (GUI.Button(new Rect(190, 180, 20, 20), "-"))
            { global.mDex--; global.skillPoint++; }
            if (GUI.Button(new Rect(140, 220, 20, 20), "+"))
            { global.mSpd++; global.skillPoint--; }
            if (GUI.Button(new Rect(190, 220, 20, 20), "-"))
            { global.mSpd--; global.skillPoint++; }
            if (GUI.Button(new Rect(140, 260, 20, 20), "+"))
            { global.mCon++; global.skillPoint--; }
            if (GUI.Button(new Rect(190, 260, 20, 20), "-"))
            { global.mCon--; global.skillPoint++; }
        }
        GUI.Label(new Rect(170, 100, 20, 20), global.mStr.ToString()); GUI.Label(new Rect(170, 140, 20, 20), global.mInt.ToString());
        GUI.Label(new Rect(170, 180, 20, 20), global.mDex.ToString()); GUI.Label(new Rect(170, 220, 20, 20), global.mSpd.ToString());
        GUI.Label(new Rect(170, 260, 20, 20), global.mCon.ToString());
    }

    void Update()
    {

    }
}
