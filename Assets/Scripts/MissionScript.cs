using UnityEngine;
using System.Collections;

public class MissionScript : MonoBehaviour {

    public Spawner spawn;
    public GameObject goodGuy;
    public GameObject badGuy;

	// Use this for initialization
	void Start ()
    {
        spawn = GameObject.Find("ScriptManager").GetComponent<Spawner>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}


    public void Mission1(int missionID)
    {
        
    }
}
