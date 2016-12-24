using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoodGuy : MonoBehaviour
{

<<<<<<< HEAD:Assets/Scripts/GoodGuy.cs
    //base stats
    int bStr = 1;
    int bInt = 1;
    int bDex = 1;
    int bSpd = 1;
    int bCon = 1;

    //modified stats
    public int mStr;
    public int mInt;
    public int mDex;
    public int mSpd;
    public int mCon;

=======
>>>>>>> origin/ArenaDevBranch:Assets/Scripts/Hero Scripts/GoodGuy.cs
    public int attk;
    public int maxHP;
    public int currentHP;
    public float speed;

    public int level;
    public int currentExp;
    public int expToLevel;
    public GameObject thisObject;

    public GameControl badGuy;

    public GameObject scriptManager;
    public TargetSelection targetScript;
    public CombatSys combatScript;

    public Animator playerAnimator;

    // Use this for initialization
    void Start()
    {
        thisObject = gameObject;
        level = 1;
        expToLevel = 100;
        maxHP = 10;
        speed = 50f;
        currentHP = maxHP;
        scriptManager = GameObject.Find("ScriptManager");
        combatScript = scriptManager.GetComponent<CombatSys>();
        targetScript = scriptManager.GetComponent<TargetSelection>();

        

        playerAnimator = thisObject.GetComponent<Animator>();
        playerAnimator.enabled = false;

    }

    public void AniEventCall()
    {

        Debug.Log("Called from animation");

        combatScript.AttackSystem(gameObject, GameObject.Find("BadGuy")/*find way to push proper gameobject*/, true, false);
    }

    public void Clicked()
    {
        RadialMenuCall();
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void RadialMenuCall()
    {
        //enable the animator component
        playerAnimator.enabled = true;
        //play the Slidein animation
        playerAnimator.Play("RadialMenu");
    }

    public void AttackAnimation()
    {
        playerAnimator.Play("RadialMenuFadeOut");
        playerAnimator.Play("GoodGuyAttack");
    }
}