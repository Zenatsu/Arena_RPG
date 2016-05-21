using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyTurn : IBattleState
{
    private readonly BattleStatePattern battle;
    BadGuy badGuy;
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
        Debug.Log("Arrived at Enemy Turn");
        battle.goodGuy.GetComponent<Button>().interactable = false;
        badGuy = battle.badGuy.GetComponent<BadGuy>();
        AttackPlayer();
    }

    public void AttackPlayer()
    {
        caseSwitch = Random.Range(Mathf.RoundToInt(1f), Mathf.RoundToInt(3f));
        badGuy.AttackFlash();
        switch (caseSwitch)
        {
            case 1:
                Debug.Log("Attack the player");
                //play attack animation

                //Check if player is dead
                if (battle.goodGuy.GetComponent<GoodGuy>().currentHP <= 0)
                {
                    //go to Battle Lost
                }
                else
                    //go to playerTurn
                    ToPlayerTurn();
                break;
            case 2:
                Debug.Log("Use Ability 1 on player");
                //play attack animation

                //Check if player is dead
                if (battle.goodGuy.GetComponent<GoodGuy>().currentHP <= 0)
                {
                    //go to Battle Lost
                }
                else
                    //go to playerTurn
                    ToPlayerTurn();
                break;
            default:
                Debug.Log("Default case");
                //probably just the attack function agian
                //play attack animation

                //Check if player is dead
                if (battle.goodGuy.GetComponent<GoodGuy>().currentHP >= 0)
                {
                    //go to Battle Lost
                }
                else
                    //go to playerTurn
                    ToPlayerTurn();
                break;
        }
    }

    public void ToStartCombat()
    {

    }

    public void ToPlayerTurn()
    {
        Debug.Log("Going to Player Turn");
        battle.playerTurn = true;       
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



}
