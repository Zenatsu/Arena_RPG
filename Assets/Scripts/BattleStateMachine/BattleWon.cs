using UnityEngine;
using System.Collections;

public class BattleWon : IBattleState
{

    private readonly BattleStatePattern battle;

    public BattleWon(BattleStatePattern battleStatePattern)
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
        Debug.Log("Can't transition to same state");
    }

    public void ToBattleLost()
    {

    }

    public void ToBlankState()
    {
        
    }
}
