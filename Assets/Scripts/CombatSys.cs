using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CombatSys : MonoBehaviour {

    //this class handles the combat system

    public GameObject badGuy;
    public GameObject goodGuy;
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
        fightButton.GetComponent<Button>().interactable = false;
        fightButton.GetComponent<Button>().image.enabled = false;
        fightButton.GetComponentInChildren<Text>().enabled = false;
        casePos = Random.Range(1, 4);
        print("Case: " + casePos);

        goodGuy = (GameObject)Instantiate(goodGuy, gPos1, Quaternion.identity);
        
        switch(casePos)
        {
            case 1:
                badGuy = (GameObject)Instantiate(badGuy, bPos1, Quaternion.identity);
                badGuy.name = "BadGuy";
                break;
            case 2:
                badGuy = (GameObject)Instantiate(badGuy, bPos1, Quaternion.identity);
                badGuy.name = "BadGuy";
                badGuy = (GameObject)Instantiate(badGuy, bPos2, Quaternion.identity);
                badGuy.name = "BadGuy2";
                break;
            case 3:
                badGuy = (GameObject)Instantiate(badGuy, bPos1, Quaternion.identity);
                badGuy.name = "BadGuy";
                badGuy = (GameObject)Instantiate(badGuy, bPos2, Quaternion.identity);
                badGuy.name = "BadGuy2";
                badGuy = (GameObject)Instantiate(badGuy, bPos3, Quaternion.identity);
                badGuy.name = "BadGuy3";
                break;
        }

    }

}