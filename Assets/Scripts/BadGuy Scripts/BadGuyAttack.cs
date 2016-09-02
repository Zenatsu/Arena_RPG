using UnityEngine;
using System.Collections;

public class BadGuyAttack : MonoBehaviour {

    CombatSys combatSys;
    GameObject goodGuy;
    GameObject thisObject;
    public BattleStatePattern battle;

    void Start()
    {
        combatSys = GameObject.Find("ScriptManager").GetComponent<CombatSys>();
        goodGuy = GameObject.Find("Player");
        thisObject = gameObject;
        battle = GameObject.Find("ScriptManager").GetComponent<BattleStatePattern>();
    }

    IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(2f);
        battle.hasAttacked = true;
    }

    public void AttackPlayer()
    {
        battle.hasAttacked = true;
        combatSys.AttackSystem(goodGuy, thisObject, false, true);
    }

    
}
