using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TargetSelection : MonoBehaviour {

    List<Transform> _targets;
    public Transform selectedTarget;
    public bool targeting = false;
    public bool targeted = false;

    public BattleStatePattern battle;
    CombatSys combatSys;
    public GameObject player;
    public GameObject hero1;
    public GameObject hero2;
    GameObject script;


    // Use this for initialization
    void Start ()
    {
        _targets = new List<Transform>();
        selectedTarget = null;
        player = GameObject.Find("Player");
        script = GameObject.Find("ScriptManager");
        battle = script.GetComponent<BattleStatePattern>();
        combatSys = script.GetComponent<CombatSys>();
        AddAllEnemies();
	}

    private void AddAllEnemies() //add all objects with tag "Enemy"
    {
        GameObject[] _enemyList = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in _enemyList)
            AddTarget(enemy.transform);
    }

    public void AddTarget(Transform enemy)
    {
        _targets.Add(enemy);
    }

    public void TargetEnemy()
    {
        if (selectedTarget == null)
        {
            selectedTarget = _targets[0];
            targeted = true;
        }

        else
        {
            int index = _targets.IndexOf(selectedTarget);

            if (index < _targets.Count - 1)
                index++;
            else
                index = 0;

            DeselectTarget();
            selectedTarget = _targets[index];
        }

        SelectTarget();
    }

    private void SelectTarget()
    {
        if (selectedTarget != null)
            (selectedTarget.GetComponent("Halo") as Behaviour).enabled = true;
                   
    }


    private void DeselectTarget()
    {
        if (selectedTarget != null)
            (selectedTarget.GetComponent("Halo") as Behaviour).enabled = false;
        selectedTarget = null;

    }
    public void AniAttackTarget()
    {

        Debug.Log("Called From Animation " + System.Environment.NewLine + "attacking: " + selectedTarget);
        //access attack system in CombatSys script, and send game object information
        combatSys.AttackSystem(player, selectedTarget.gameObject, true);

    }
    IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(1.5f);
    }

    public void ConfirmTarget()
    {

        if (targeted && (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)))
        {
            //switch targeting and targetd off after attack
            targeted = false;
            targeting = false;
            battle = GameObject.Find("ScriptManager").GetComponent<BattleStatePattern>();
            if(battle.heroTurn)
                player.GetComponent<GoodGuy>().AttackAnimation();
            if(battle.hero1Turn)
                hero1.GetComponent<GoodGuy>().AttackAnimation();
            if(battle.hero2Turn)
                hero2.GetComponent<GoodGuy>().AttackAnimation();
            StartCoroutine(WaitForAnim());
            
            battle.playerTurn = false;
            battle.heroTurn = false;
            battle.hero1Turn = false;
            battle.hero2Turn = false;

        }   
                        
    }



    public void OnAttackClick()
    {
        targeting = !targeting; //Bool toggle to set if targeting system is active
               
    }

    public void OnAbilityClick()
    {
        targeting = !targeting; //Bool toggle to set if targeting system is active

    }

    // Update is called once per frame
    void Update()
    {
        if (battle.heroCheck.hero1)
            hero1 = GameObject.Find("Hero1");
        if (battle.heroCheck.hero2)
            hero2 = GameObject.Find("Hero2");


        //Tab Switching
        if (targeting && Input.GetKeyDown(KeyCode.Tab))
            TargetEnemy();
        
        //Mouse Selecting
        if (targeting && Input.GetMouseButtonDown(0))
        {
            //setting up raycast
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits;
            hits = Physics2D.RaycastAll(mousePos, Vector3.zero);//cast a ray from mouse pointer
            bool gotTarget = false;

            foreach (RaycastHit2D hit in hits)//when something is hit
            {
                DeselectTarget(); //Deselect previous target
                selectedTarget = hit.transform; //grab hit object
                SelectTarget(); // select target
                gotTarget = true;
                targeted = true;
                break;
            }

            if (!gotTarget) //if nothing was clicked deselect
            {
                gotTarget = false;
                DeselectTarget();
                targeted = false;

            }

        }
        if (targeted)
            ConfirmTarget();
    }
}