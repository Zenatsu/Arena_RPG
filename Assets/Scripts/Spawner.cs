using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public GameObject badGuy;
    public GameObject badGuy2;
    public GameObject badGuy3;
    public GameObject goodGuy;
    public GameObject hero1;
    public GameObject hero2;
    GameObject control;
    HeroCheck heroCheck;
    GoodGuy player;
    BadGuy enemy;

    

    public BattleStatePattern battle;

    //posistions for good guys -- might not be needed
    Vector3 gTop = new Vector3(-4, 3, 0);
    Vector3 gMid = new Vector3(-4, 0, 0);
    Vector3 gBot = new Vector3(-4,-3, 0);

    //posistions for bad guys
    Vector3 bTop = new Vector3(3, 2, 0);
    Vector3 bMid = new Vector3(3, 0, 0);
    Vector3 bBot = new Vector3(3, -2, 0);
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

    public void SpawnSystem(GameObject spawnPlayer, GameObject spawnEnemy, int[] levelData)
    {

        Debug.Log("From Spawner - levelData: " + levelData[0]);
        //GoodGuy Spawns
        if (!heroCheck.hero1 && !heroCheck.hero2)
        {
            Debug.Log("No hero's bought, spawn in the middle");
            spawnPlayer = Instantiate(goodGuy, gMid, Quaternion.identity) as GameObject;
            spawnPlayer.name = "Player";
            spawnPlayer.GetComponent<GoodGuy>().attk = 1;
            spawnPlayer.GetComponent<GoodGuy>().maxHP = 10;
        }
        else
        {
            Debug.Log("Hero 1 bought, moving to top spawn");
            spawnPlayer = Instantiate(goodGuy, gTop, Quaternion.identity) as GameObject;
            spawnPlayer.name = "Player";
            spawnPlayer.GetComponent<GoodGuy>().attk = 1;
            spawnPlayer.GetComponent<GoodGuy>().maxHP = 10;
        }
        

        if (heroCheck.hero1 && !heroCheck.hero2)
        {
            spawnPlayer = Instantiate(hero1, gMid, Quaternion.identity) as GameObject;
            spawnPlayer.name = "Hero1";
            spawnPlayer.GetComponent<Animator>().enabled = false;
            spawnPlayer.GetComponent<GoodGuy>().attk = 2;
            spawnPlayer.GetComponent<GoodGuy>().maxHP = 20;
        }
        else if (!heroCheck.hero1 && heroCheck.hero2)
        {
            spawnPlayer = Instantiate(hero2, gMid, Quaternion.identity) as GameObject;
            spawnPlayer.name = "Hero2";
            spawnPlayer.GetComponent<GoodGuy>().attk = 3;
            spawnPlayer.GetComponent<GoodGuy>().maxHP = 30;
        }
        else if(heroCheck.hero1 && heroCheck.hero2)
        {
            spawnPlayer = Instantiate(hero1, gMid, Quaternion.identity) as GameObject;
            spawnPlayer.name = "Hero1";
            spawnPlayer.GetComponent<GoodGuy>().attk = 3;
            spawnPlayer.GetComponent<GoodGuy>().maxHP = 30;

            spawnPlayer = Instantiate(hero2, gBot, Quaternion.identity) as GameObject;
            spawnPlayer.name = "Hero2";
            spawnPlayer.GetComponent<GoodGuy>().attk = 3;
            spawnPlayer.GetComponent<GoodGuy>().maxHP = 30;
        }

        int randy = Mathf.FloorToInt(Random.Range(1, levelData[1]+1));

        Debug.Log("Randy's number: " + randy);
        if (levelData[1] != 4)
        {
            switch (randy)
            {
                case 1:
                    // spawn 1 duder
                    spawnEnemy = Instantiate(badGuy, bMid, Quaternion.identity) as GameObject;
                    spawnEnemy.name = "BadGuy";
                    spawnEnemy.GetComponent<BadGuy>().attk = 1;
                    spawnEnemy.GetComponent<BadGuy>().maxHP = 10 * levelData[1];
                    battle.enemy1Spawned = true;
                    break;
                case 2:
                    // spawn 2 duders
                    spawnEnemy = Instantiate(badGuy, bTop, Quaternion.identity) as GameObject;
                    spawnEnemy.name = "BadGuy";
                    spawnEnemy.GetComponent<BadGuy>().attk = 1;
                    spawnEnemy.GetComponent<BadGuy>().maxHP = 10 * levelData[1];
                    battle.enemy1Spawned = true;

                    spawnEnemy = Instantiate(badGuy, bMid, Quaternion.identity) as GameObject;
                    spawnEnemy.name = "BadGuy2";
                    spawnEnemy.GetComponent<BadGuy>().attk = 1;
                    spawnEnemy.GetComponent<BadGuy>().maxHP = 10;
                    battle.enemy2Spawned = true;
                    break;
                case 3:
                    //spawn 3 duders
                    spawnEnemy = Instantiate(badGuy, bTop, Quaternion.identity) as GameObject;
                    spawnEnemy.name = "BadGuy";
                    spawnEnemy.GetComponent<BadGuy>().attk = 1;
                    spawnEnemy.GetComponent<BadGuy>().maxHP = 10 * levelData[1];
                    battle.enemy1Spawned = true;

                    spawnEnemy = Instantiate(badGuy, bMid, Quaternion.identity) as GameObject;
                    spawnEnemy.name = "BadGuy2";
                    spawnEnemy.GetComponent<BadGuy>().attk = 1;
                    spawnEnemy.GetComponent<BadGuy>().maxHP = 10;
                    battle.enemy2Spawned = true;

                    spawnEnemy = Instantiate(badGuy, bBot, Quaternion.identity) as GameObject;
                    spawnEnemy.name = "BadGuy3";
                    spawnEnemy.GetComponent<BadGuy>().attk = 1;
                    spawnEnemy.GetComponent<BadGuy>().maxHP = 10;
                    battle.enemy3Spawned = true;

                    break;
            }
        }
        else
        {
            //spawn boss
            switch (levelData[0])
            {
                case 5:
                    print("Level 5 boss GO!");
                    // level 5 boss
                    break;
                case 10:
                    print("Level 10 boss GO!");
                    // level 10 boss
                    break;
                case 11:
                    print("Level 11 boss GO!");
                    // final boss
                    break;
            }
        }
    }
}
