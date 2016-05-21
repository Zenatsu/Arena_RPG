using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoodGuy : MonoBehaviour {

    public int attk;
    public int maxHP;
    public int currentHP;
    public float speed;
    public GameObject player;
    public Animator playerAttackAnimation;

    public GameObject scriptManager;
    public CombatSys combatScript;

    public Animator playerAnimator;
    public Animation playerAnimation;

    // Use this for initialization
    void Start()
    {
        name = "Player";
        player = GameObject.FindGameObjectWithTag("Player");
        playerAttackAnimation = player.GetComponent<Animator>();

        maxHP = 10;
        speed = 50f;
        currentHP = maxHP;
        scriptManager = GameObject.Find("ScriptManager");
        combatScript = scriptManager.GetComponent<CombatSys>();

        playerAnimator = player.GetComponent<Animator>();
        playerAnimator.enabled = false;

        playerAnimation = player.GetComponent<Animation>();
    }

    IEnumerator WaitAndPlay(float waitTime, Animator anim)
    {
        anim.Play("GoodGuyAttack");
        yield return new WaitForSeconds(waitTime);
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
