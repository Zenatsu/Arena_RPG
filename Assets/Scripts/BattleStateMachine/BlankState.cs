using UnityEngine;
using System.Collections;

public class BlankState : IBattleState
{

    private readonly BattleStatePattern battle;

    public BlankState(BattleStatePattern battleStatePattern)
    {
        battle = battleStatePattern;

    }

    public void UpdateState()
    {
        
    }

    public void ToStartCombat()
    {

    }

    public void ToPlayerTurn()
    {

    }

    public void ToEnemyTurn()
    {

    }

    public void ToBattleWon()
    {

    }

    public void ToBattleLost()
    {
        
    }

    public void ToBlankState()
    {
        Debug.Log("Can't transition to same state");
    }

}
