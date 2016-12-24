using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class BattleStatePattern : MonoBehaviour {

    public GameObject SpawnBadGuy;
    public GameObject spawnGoodGuy;

    public GameObject goodGuy;
    public GameObject hero1;
    public GameObject hero2;

    public GameObject badGuy;
    public GameObject badGuy2;
    public GameObject badGuy3;
    public bool enemy1Spawned;
    public bool enemy2Spawned;
    public bool enemy3Spawned;

    public Spawner spawn;
    GoodGuy player;
    BadGuy enemy;
    public HeroCheck heroCheck;

    public GameObject missionButton;

    List<GameObject> _enemyList;

    GameObject[] missionButtonArray;

    //posistions for good guys -- might not be needed
    Vector3 gPos1 = new Vector3(-6, 0, 0);
    Vector3 gPos2;
    Vector3 gPos3;

    //posistions for bad guys
    Vector3 bPos1 = new Vector3(3, 3, 0);
    Vector3 bPos2 = new Vector3(3, 1, 0);
    Vector3 bPos3 = new Vector3(3, -1, 0);

    //var for spawn case
    int casePos = 1;

    [HideInInspector]
    public IBattleState currentState;
    [HideInInspector]
    public StartCombat startCombatState;
    [HideInInspector]
    public PlayerTurn playerTurnState;
    [HideInInspector]
    public EnemyTurn enemyTurnState;
    [HideInInspector]
    public BattleWon battleWonState;
    [HideInInspector]
    public BattleLost battleLostState;
    [HideInInspector]
    public BlankState blankState;

    public bool hasAttacked;
    public int playerTurnCount = 1;
    public int enemyTurnCount = 1;
    public bool playerTurn;
    public bool heroTurn;
    public bool hero1Turn;
    public bool hero2Turn;
    public bool enemyTurn;
    public bool enemy1Turn;
    public bool enemy2Turn;
    public bool enemy3Turn;

    private void Awake()
    {
        startCombatState = new StartCombat(this);
        playerTurnState = new PlayerTurn(this);
        enemyTurnState = new EnemyTurn(this);
        battleLostState = new BattleLost(this);
        battleWonState = new BattleWon(this);
        blankState = new BlankState(this);
        currentState = blankState;

        missionButtonArray = GameObject.FindGameObjectsWithTag("MissionButton");

    }

    // Use this for initialization
    void Start()
    {
        player = spawnGoodGuy.GetComponent<GoodGuy>();
        enemy = SpawnBadGuy.GetComponent<BadGuy>();
        heroCheck = GameObject.Find("GameController").GetComponent<HeroCheck>();

    }

    public void SelectLevel(int ID)
    {

        int[] levelData = levelDatabase[ID];
        spawn.SpawnSystem(spawnGoodGuy, SpawnBadGuy, levelData);
        currentState = startCombatState;
        DisableButtons();
    }

    // an array of arrays. Stores the following in order:
    // [0] - Level#, [1] max # of bad guys to spawn, [2] - doseage amount of steroides for bad guys

    public static int[][] levelDatabase = new int[][]
    {

        new int[] { 1, 1, 100 },new int[] { 2, 1, 500 },new int[] { 3, 2, 1000 },new int[] { 4, 2, 1000 },
        new int[] { 5, 4, 100 },new int[] { 6, 3, 500 },new int[] { 7, 3, 1000 },new int[] { 8, 3, 1000 },
        new int[] { 9, 3, 100 },new int[] { 10, 4, 500 },new int[] { 11, 4, 1000 },


    };

    private void DisableButtons()
    {

        foreach (GameObject missionButton in missionButtonArray)
        {
            missionButton.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
        goodGuy = GameObject.Find("Player");
        badGuy = GameObject.Find("BadGuy");
        badGuy2 = GameObject.Find("BadGuy2");
        badGuy3 = GameObject.Find("BadGuy3");

        if (heroCheck.hero1)
            hero1 = GameObject.Find("Hero1");
        if (heroCheck.hero2)
            hero2 = GameObject.Find("Hero2");
    }


}
