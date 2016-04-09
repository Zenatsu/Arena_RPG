using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class TargetSelection : MonoBehaviour {

    List<Transform> _targets;
    public Transform selectedTarget;
    public bool targeting = false;
    

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
            selectedTarget = _targets[0];
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

    public void OnClick()
    {
        targeting = !targeting; //Bool toggle to set if targeting system is active
    }

    // Update is called once per frame
    void Update ()
    {
        if(targeting && Input.GetKeyDown(KeyCode.Tab))
        {
            TargetEnemy(); //target
        }

        if (!targeting)
            DeselectTarget();

        if (targeting && Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits; 
            hits = Physics2D.RaycastAll(mousePos, Vector3.zero);//cast a ray from mouse pointer
            bool gotTarget = false;

            foreach(RaycastHit2D hit in hits)
            {
                DeselectTarget();
                selectedTarget = hit.transform;
                SelectTarget();
                gotTarget = true;
            }
           
            if (!gotTarget) //if nothing was clicked deselect
                DeselectTarget();

        }


    }
}
