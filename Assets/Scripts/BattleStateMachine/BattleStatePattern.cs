using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BattleStatePattern : MonoBehaviour {

    public GameObject SpawnBadGuy;
    public GameObject badGuy;
    public GameObject spawnGoodGuy;
    public GameObject goodGuy;
    
    public GameObject hero1;
    public GameObject hero2;

    GoodGuy player;
    BadGuy enemy;
    public HeroCheck heroCheck;

    public Transform fightButton;
    List<GameObject> _enemyList;

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
    public bool playerTurn;
    public bool heroTurn;
    public bool hero1Turn;
    public bool hero2Turn;
    public bool enemyTurn;

    
    private void Awake()
    {
        startCombatState = new StartCombat(this);
        playerTurnState = new PlayerTurn(this);
        enemyTurnState = new EnemyTurn(this);
        battleLostState = new BattleLost(this);
        battleWonState = new BattleWon(this);
        blankState = new BlankState(this);
        currentState = blankState;
        
    }

    // Use this for initialization
    void Start()
    {
        player = spawnGoodGuy.GetComponent<GoodGuy>();
        enemy = SpawnBadGuy.GetComponent<BadGuy>();
        heroCheck = GameObject.Find("GameController").GetComponent<HeroCheck>();
    }

    public void OnButtonPressed()
    {
        currentState = startCombatState;
        
        fightButton.GetComponent<Button>().interactable = false;
        fightButton.GetComponent<Button>().image.enabled = false;
        fightButton.GetComponentInChildren<Text>().enabled = false;
    }
	// Update is called once per frame
	void Update()
    {
        currentState.UpdateState();
        goodGuy = GameObject.Find("Player");
        badGuy = GameObject.FindGameObjectWithTag("Enemy");
        if(heroCheck.hero1)
            hero1 = GameObject.Find("Hero1");
        if(heroCheck.hero2)
            hero2 = GameObject.Find("Hero2");
    }


}
