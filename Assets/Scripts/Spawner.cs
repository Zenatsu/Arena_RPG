using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject badGuy;
    public GameObject goodGuy;
    public GameObject hero1;
    public GameObject hero2;
    public GameObject control;
    HeroCheck heroCheck;
    GoodGuy player;
    BadGuy enemy;

    BattleStatePattern battle;

    //posistions for good guys -- might not be needed
    Vector3 gPos1 = new Vector3(-6, 3, 0);
    Vector3 gPos2 = new Vector3(-6, 0, 0);
    Vector3 gPos3 = new Vector3(-6,-3, 0);

    //posistions for bad guys
    Vector3 bPos1 = new Vector3(3, 3, 0);
    Vector3 bPos2 = new Vector3(3, 1, 0);
    Vector3 bPos3 = new Vector3(3, -1, 0);

    // Use this for initialization
    void Start ()
    {
        control = GameObject.Find("GameController");
        heroCheck = control.GetComponent<HeroCheck>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void SpawnSystem(GameObject spawnPlayer, GameObject spawnEnemy)
    {

        if(heroCheck.hero1 == false)
        {
            Debug.Log("No hero's bought, spawn in the middle");
            spawnPlayer = Instantiate(goodGuy, gPos2, Quaternion.identity) as GameObject;
            spawnPlayer.name = "Player";
            spawnPlayer.GetComponent<GoodGuy>().attk = 1;
            spawnPlayer.GetComponent<GoodGuy>().maxHP = 10;
        }
        else
        {
            Debug.Log("Hero 1 bought, moving to top spawn");
            spawnPlayer = Instantiate(goodGuy, gPos1, Quaternion.identity) as GameObject;
            spawnPlayer.name = "Player";
            spawnPlayer.GetComponent<GoodGuy>().attk = 1;
            spawnPlayer.GetComponent<GoodGuy>().maxHP = 10;
        }
        

        if (heroCheck.hero1 == true)
        {
            spawnPlayer = Instantiate(hero1, gPos2, Quaternion.identity) as GameObject;
            spawnPlayer.name = "Hero1";
            spawnPlayer.GetComponent<Animator>().enabled = false;
            spawnPlayer.GetComponent<GoodGuy>().attk = 2;
            spawnPlayer.GetComponent<GoodGuy>().maxHP = 20;
        }
        if (heroCheck.hero2 == true)
        {
            spawnPlayer = Instantiate(hero2, gPos3, Quaternion.identity) as GameObject;
            spawnPlayer.name = "Hero2";
            spawnPlayer.GetComponent<GoodGuy>().attk = 3;
            spawnPlayer.GetComponent<GoodGuy>().maxHP = 30;
        }

        spawnEnemy = Instantiate(badGuy, bPos1, Quaternion.identity) as GameObject;
        spawnEnemy.GetComponent<BadGuy>().attk = 1;
        spawnEnemy.GetComponent<BadGuy>().maxHP = 10;
        
    }
}
