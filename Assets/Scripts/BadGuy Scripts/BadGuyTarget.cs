using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BadGuyTarget : MonoBehaviour {

    List<Transform> _targets;
    public Transform selectedTarget;


	// Use this for initialization
	void Start ()
    {
        _targets = new List<Transform>();
        selectedTarget = null;
        AddAllTargets();
	}

    void AddAllTargets()
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
        if(selectedTarget == null)
        {
            selectedTarget = _targets[0];
        }
        else
        {
            int index = _targets.IndexOf(selectedTarget);
            if (index < _targets.Count - 1)
                index++;
            else
                index = 0;

            selectedTarget = _targets[index];
        }

        SelectTarget();
    }

    void SelectTarget()
    {
        print("I choose to attack: "+selectedTarget);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
