using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BadGuy : MonoBehaviour {

    //This class handles individual bad guys

    public GameObject prefab;
    public bool badGuyTargeted;
    public Behaviour halo;
    public int maxHP;
    public int currentHP;
    public int attk;
    public int speed;

    [HideInInspector]
    public Slider maxHPBar;


    public bool badHasAttacked;
    // Use this for initialization
    void Start()
    {
        currentHP = maxHP;
        name = "BadGuy";
        Color randColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        GetComponent<SpriteRenderer>().color = randColor;
        maxHPBar = prefab.GetComponentInChildren<Slider>();
        maxHPBar.maxValue = maxHP;
        maxHPBar.minValue = 0;

        halo = (Behaviour)GetComponent("Halo");
    }

    void OnMouseEnter()
    {
        //find the script within player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        TargetSelection targetScript = player.GetComponent<TargetSelection>();
        badGuyTargeted = targetScript.targeting;

        if(badGuyTargeted)
            halo.enabled = true;

    }

    void OnMouseExit()
    {
        halo.enabled = false;

    }

    IEnumerator HaloFlash()
    {
        halo.enabled = true;
        yield return new WaitForSeconds(.05f);
        halo.enabled = false;
        yield return new WaitForSeconds(.05f);

        halo.enabled = true;
        yield return new WaitForSeconds(.05f);
        halo.enabled = false;
        yield return new WaitForSeconds(.05f);

        halo.enabled = true;
        yield return new WaitForSeconds(.05f);
        halo.enabled = false;
        yield return new WaitForSeconds(.05f);

    }

    public void AttackFlash()
    {
        StartCoroutine(HaloFlash());
    }

// Update is called once per frame
    void Update()
    {
        maxHPBar.value = currentHP;
        if (currentHP < 1)
        {
            //Destroy(gameObject);
        }
        
    }
}
