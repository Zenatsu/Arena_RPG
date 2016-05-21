using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject badGuy;
    public GameObject goodGuy;
    GoodGuy player;
    BadGuy enemy;

    BattleStatePattern battle;

    //posistions for good guys -- might not be needed
    Vector3 gPos1 = new Vector3(-6, 0, 0);
    Vector3 gPos2;
    Vector3 gPos3;

    //posistions for bad guys
    Vector3 bPos1 = new Vector3(3, 3, 0);
    Vector3 bPos2 = new Vector3(3, 1, 0);
    Vector3 bPos3 = new Vector3(3, -1, 0);

    // Use this for initialization
    void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void SpawnSystem(GameObject spawnPlayer, GameObject spawnEnemy)
    {
        spawnPlayer = Instantiate(goodGuy, gPos1, Quaternion.identity) as GameObject;        
        spawnPlayer.name = "Player";
        spawnPlayer.GetComponent<GoodGuy>().attk = 1;
        spawnPlayer.GetComponent<GoodGuy>().maxHP = 10;

        spawnEnemy = Instantiate(badGuy, bPos1, Quaternion.identity) as GameObject;
        spawnEnemy.GetComponent<BadGuy>().attk = 1;
        spawnEnemy.GetComponent<BadGuy>().maxHP = 10;
        
    }
}
