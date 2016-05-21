using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerTurn : IBattleState
{

    private readonly BattleStatePattern battle;
    GoodGuy player;

    bool hasAttacked;

    public PlayerTurn(BattleStatePattern battleStatePattern)
    {
        battle = battleStatePattern;

    }

    public void UpdateState()
    {
        start();
    }

    void start()
    {
        battle.goodGuy.GetComponent<Button>().interactable = true;
        player = battle.goodGuy.GetComponent<GoodGuy>();

        if(battle.playerTurn)
            player.RadialMenuCall();

        if (battle.hasAttacked)
        {
            if (battle.badGuy.GetComponent<BadGuy>().currentHP <= 0)
                ToBattleWon();
            else
                ToEnemyTurn();
                
        }

    }


    public void ToStartCombat()
    {

    }

    public void ToPlayerTurn()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToEnemyTurn()
    {
        Debug.Log("Player has attacked, going to enemy turn");
        battle.hasAttacked = false;
        battle.currentState = battle.enemyTurnState;
    }

    public void ToBattleWon()
    {
        Debug.Log("Going to Battle Won");
    }

    public void ToBattleLost()
    {

    }

}
