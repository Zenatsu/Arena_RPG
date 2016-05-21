using UnityEngine;
using System.Collections;

public class BattleWon : MonoBehaviour {

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
}
