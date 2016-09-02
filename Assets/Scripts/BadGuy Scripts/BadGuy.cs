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
    public bool finishedFlashing;
    [HideInInspector]
    public Slider maxHPBar;
    public BattleStatePattern battle;

    public bool badHasAttacked;

    public Animation badGuyAnimation;

    
    // Use this for initialization
    void Start()
    {
        currentHP = maxHP;
        Color randColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        GetComponent<SpriteRenderer>().color = randColor;
        maxHPBar = prefab.GetComponentInChildren<Slider>();
        maxHPBar.maxValue = maxHP;
        maxHPBar.minValue = 0;

        badGuyAnimation = GetComponent<Animation>();

        battle = GameObject.Find("ScriptManager").GetComponent<BattleStatePattern>();

        halo = (Behaviour)GetComponent("Halo");
    }

    void OnMouseEnter()
    {
        //find the script within player
        GameObject player = GameObject.Find("Player");
        TargetSelection targetScript = player.GetComponent<TargetSelection>();
        badGuyTargeted = targetScript.targeting;

        if(badGuyTargeted)
            halo.enabled = true;

    }

    void OnMouseExit()
    {
        halo.enabled = false;

    }

    public IEnumerator WaitforAnim()
    {
        Debug.Log("Waiting for badguy Animation");
        yield return new WaitForSeconds(.42f);
        finishedFlashing = true;
    }

    public void badGuyAnim()
    {
        badGuyAnimation.Play();
        StartCoroutine(WaitforAnim());
        

    }

// Update is called once per frame
    void Update()
    {
        maxHPBar.value = currentHP;
        if (currentHP < 1)
        {
            //Play death Animation
            //Destroy(gameObject);
        }
        
    }
}
