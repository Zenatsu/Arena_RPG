using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class TargetSelection : MonoBehaviour {

    List<Transform> _targets;
    public Transform selectedTarget;
    public bool targeting = false;
    bool targeted = false;

    //int clickCount;
    bool doubleClick = false;
    

    // Use this for initialization
    void Start ()
    {
        _targets = new List<Transform>();
        selectedTarget = null;

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
;
    }


    private void DeselectTarget()
    {
        if (selectedTarget != null)
            (selectedTarget.GetComponent("Halo") as Behaviour).enabled = false;

        selectedTarget = null;
        doubleClick = false;
    }

    public void ConfirmTarget()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject script = GameObject.Find("ScriptManager");
        CombatSys combatSys = script.GetComponent<CombatSys>();

        /*if (clickCount >= 2) //leaving this here if/when I want to utilize this
        {
            doubleClick = true;
            clickCount =0;
        }*/

        if (targeted && (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)))
        {
            
            
            combatSys.AttackSystem(player, selectedTarget.gameObject);

            print("Target Confirmed, commense damage dealing on target " + selectedTarget + "!");
        }
            
            
    }

    public void OnClick()
    {
        targeting = !targeting; //Bool toggle to set if targeting system is active
        //clickCount = 0;
        
    }

    // Update is called once per frame
    void Update ()
    {
        //Tab Switching
        if (targeting && Input.GetKeyDown(KeyCode.Tab))
        {
            TargetEnemy();
            print(selectedTarget);
            //clickCount = 0;
        }

        if (!targeting)
            DeselectTarget();

        //Mouse Selecting
        if (targeting && Input.GetMouseButtonDown(0))
        {
            //setting up raycast
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits; 
            hits = Physics2D.RaycastAll(mousePos, Vector3.zero);//cast a ray from mouse pointer
            bool gotTarget = false;

            foreach(RaycastHit2D hit in hits)//when something is hit
            { 
                DeselectTarget();
                selectedTarget = hit.transform;
                SelectTarget();
                gotTarget = true;
                targeted = true;
                //clickCount ++;
            }

            if (!gotTarget) //if nothing was clicked deselect
            {
                gotTarget = false;
                DeselectTarget();
                targeted = false;
            }
            
        }
        
        if(targeted)
            ConfirmTarget();
    }
}