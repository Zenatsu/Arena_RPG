using UnityEngine;
using System.Collections;

public class BattleLost : IBattleState
{

    private readonly BattleStatePattern battle;

    public BattleLost(BattleStatePattern battleStatePattern)
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
        Debug.Log("Can't transition to same state");
    }

    public void ToBlankState()
    {

    }
}
