using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyTurn : IBattleState
{
    private readonly BattleStatePattern battle;
    BadGuy badGuy;
    BadGuyAttack badGuyAttack;
    int caseSwitch;

    public EnemyTurn (BattleStatePattern battleStatePattern)
    {
        battle = battleStatePattern;

    }

    public void UpdateState()
    {
        Start();
    }

    public void Start()
    {
        badGuy = battle.badGuy.GetComponent<BadGuy>();
        badGuyAttack = battle.badGuy.GetComponent<BadGuyAttack>();

        if(battle.enemyTurn)
        {
            badGuy.badGuyAnim();
            battle.enemyTurn = false;
        }
        

        if (badGuy.finishedFlashing)
        {
            AttackPlayer();
        }

    }

    public void AttackPlayer()
    {
        caseSwitch = Random.Range(Mathf.RoundToInt(1f), Mathf.RoundToInt(3f));
        switch (caseSwitch)
        {
            case 1:
                Debug.Log("Using Basic Attack");
                badGuyAttack.AttackPlayer();
                if (battle.hasAttacked)
                {

                    //Check if player is dead
                    if (battle.goodGuy.GetComponent<GoodGuy>().currentHP <= 0)
                        ToBattleLost();
                    else
                        ToPlayerTurn();
                }

                break;
            case 2:
                Debug.Log("Using Ability 1");
                badGuyAttack.AttackPlayer();
                if (battle.hasAttacked)
                {
                    //Check if player is dead
                    if (battle.goodGuy.GetComponent<GoodGuy>().currentHP <= 0)
                        ToBattleLost();
                    else
                        ToPlayerTurn();
                }
                break;
            default:
                Debug.Log("Default Attack Case");
                badGuyAttack.AttackPlayer();
                if (battle.hasAttacked)
                {
                    //Check if player is dead
                    if (battle.goodGuy.GetComponent<GoodGuy>().currentHP <= 0)
                        ToBattleLost();
                    else
                        ToPlayerTurn();
                }
                break;
        }
        
    }

    public void ToStartCombat()
    {

    }

    public void ToPlayerTurn()
    {
        Debug.Log("Going to Player Turn");
        badGuy.finishedFlashing = false;
        battle.hasAttacked = false;
        battle.playerTurn = true;
        if (battle.playerTurnCount == 1)
            battle.heroTurn = true;
        if (battle.playerTurnCount == 2)
            battle.hero1Turn = true;
        if (battle.playerTurnCount == 3)
            battle.hero2Turn = true;
        battle.currentState = battle.playerTurnState;
    }

    public void ToEnemyTurn()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToBattleWon()
    {

    }

    public void ToBattleLost()
    {
        Debug.Log("Going to Battle Lost");
    }

    public void ToBlankState()
    {

    }

}
