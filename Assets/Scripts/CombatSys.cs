using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class CombatSys : MonoBehaviour {

    //this class handles the combat system

    public GameObject badGuy;
    public GameObject goodGuy;
    public BattleStatePattern battle;
    GoodGuy player;
    BadGuy enemy;
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

    //Var for our case
    int casePos = 1;

    // Use this for initialization
    void start ()
    {
        _enemyList = new List<GameObject>();
        battle = GetComponent<BattleStatePattern>();
      
    }
	
	// Update is called once per frame
	void Update ()
    {
        player = goodGuy.GetComponent<GoodGuy>();
        enemy = badGuy.GetComponent<BadGuy>();
                    
    }

    public void CombatTimer()
    {
        player = goodGuy.GetComponent<GoodGuy>();

    }

    //recieves game object information from TargetSelection script and handles damage.
    public void AttackSystem(GameObject gg, GameObject bg, bool ggAttack = false, bool bgAttack = false)
    {
        //Grab scrips from objects
        GoodGuy ggScript = gg.GetComponent<GoodGuy>();
        BadGuy bgScript = bg.GetComponent<BadGuy>();

        if(ggAttack)
        {
            
            bgScript.currentHP -= ggScript.attk;
            battle.hasAttacked = true;
        }
            

        if (bgAttack)
        {
            ggScript.currentHP -= bgScript.attk;
            battle.hasAttacked = true;
        }
            
    }

    public void AnimationSystem()
    {
        GoodGuy playerAniamtion = GameObject.Find("Player").GetComponent<GoodGuy>();
        playerAniamtion.AttackAnimation();
        
    }

}