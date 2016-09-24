using UnityEngine;
using System.Collections;

public class GlobalStats : MonoBehaviour {

    //Base Stats
    int bStr=1;
    int bInt=1;
    int bDex=1;
    int bCon=1;
    int bSpd=1;

    //Modified Stats
    public int mStr;
    public int mInt;
    public int mDex;
    public int mSpd;
    public int mCon;

    //Skill points
    public int skillPoint;

    // Use this for initialization
    void Start ()
    {
        mStr = bStr;
        mInt = bInt;
        mDex = bDex;
        mSpd = bSpd;
        mCon = bCon;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
