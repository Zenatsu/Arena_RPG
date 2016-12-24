using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BadGuyTarget : MonoBehaviour
{

    public List<Transform> _targets;
    public Transform selectedTarget;

    public GameObject ScriptManager;
    public CombatSys combat;

    // Use this for initialization
    void Start()
    {
        ScriptManager = GameObject.Find("ScriptManager");
        combat = ScriptManager.GetComponent<CombatSys>();
        _targets = new List<Transform>();
        selectedTarget = null;
        AddAllTargets();
    }

    private void AddAllTargets()
    {
        GameObject[] _targetList = GameObject.FindGameObjectsWithTag("Hero");

        foreach (GameObject target in _targetList)
            AddTarget(target.transform);
    }

    void AddTarget(Transform target)
    {
        _targets.Add(target);
    }

    void TargetHero()
    {
        selectedTarget = _targets[Mathf.FloorToInt(Random.Range(0, _targets.Count + 1))];

        combat.AttackSystem(selectedTarget.gameObject, gameObject, false, true);
    }

    public void SelectTarget()
    {
        TargetHero();
    }
    // Update is called once per frame
    void Update()
    {

    }
}


