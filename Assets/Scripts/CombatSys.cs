using UnityEngine;
using System.Collections.Generic;

public class CombatSys : MonoBehaviour {

    //this class handles the combat system

    public GameObject prefab;
    List<GameObject> _enemyList;

    //posistions for good guys -- might not be needed
    float gPos1;
    float gPos2;
    float gPos3;

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

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print(_enemyList);
            print("Pressed 1!");
            foreach (GameObject enemy in _enemyList)
            {
                print(enemy.tag);
            }
        }

       // _enemyList.Add();
    }

    public void StartCombat()
    {
        CombatStart();       
        print("Combat Started");
        
    }

    void OnGUI()
    {
        
    }

    //Where the base combat system runs
    public void CombatStart()
    {
        casePos = Random.Range(1, 4);
        print("Case: " + casePos);
        
        switch(casePos)
        {
            case 1:
                prefab = (GameObject)Instantiate(prefab, bPos1, Quaternion.identity);
                prefab.name = "BadGuy";
                break;
            case 2:
                prefab = (GameObject)Instantiate(prefab, bPos1, Quaternion.identity);
                prefab.name = "BadGuy";
                prefab = (GameObject)Instantiate(prefab, bPos2, Quaternion.identity);
                prefab.name = "BadGuy2";
                break;
            case 3:
                prefab = (GameObject)Instantiate(prefab, bPos1, Quaternion.identity);
                prefab.name = "BadGuy";
                prefab = (GameObject)Instantiate(prefab, bPos2, Quaternion.identity);
                prefab.name = "BadGuy2";
                prefab = (GameObject)Instantiate(prefab, bPos3, Quaternion.identity);
                prefab.name = "BadGuy3";
                break;
        }

    }

}