using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroSwap : MonoBehaviour {

    //load prefabs
    public GameObject hero;
    public GameObject hero1;
    public GameObject hero2;

    Vector3 podiumPos = new Vector3(0, 0, 0);

    public List<GameObject> displayList;

    public GameObject displayedHero;
    GameObject spawnHero;
    public int currentSelectedHero = 0;

    public bool spawned = false;

    void Start()
    {
        displayList = new List<GameObject>();
        
        
    }

    public void NextHero()
    {
        spawned = false;
        if (currentSelectedHero >= 2)
        {
            currentSelectedHero = 0;
        }
        else
            currentSelectedHero++;
    }

    public void PrevHero()
    {
        spawned = false;
        if (currentSelectedHero <= 0)
        {
            currentSelectedHero = 2;
        }
        else
            currentSelectedHero--;
    }
    void DisplayHero()
    {
        
        switch (currentSelectedHero)
        {
            case 0:
                if (!spawned)
                {
                    Destroy(displayedHero);
                    displayedHero = Instantiate(hero, podiumPos, Quaternion.identity) as GameObject;
                    displayedHero.GetComponent<TargetSelection>().enabled = false;
                    displayedHero.name = "Hero";
                    spawned = true;
                }  
                break;
            case 1:
                if (!spawned)
                {
                    Destroy(displayedHero);
                    displayedHero = Instantiate(hero1, podiumPos, Quaternion.identity) as GameObject;
                    displayedHero.GetComponent<TargetSelection>().enabled = false;
                    displayedHero.name = "Hero1";
                    spawned = true;
                }
                    break;
            case 2:
                if (!spawned)
                {
                    Destroy(displayedHero);
                    displayedHero = Instantiate(hero2, podiumPos, Quaternion.identity) as GameObject;
                    displayedHero.GetComponent<TargetSelection>().enabled = false;
                    displayedHero.name = "Hero2";
                    spawned = true;
                }
                break;
        }
        
    }
    void Update()
    {
        DisplayHero();
    }
}