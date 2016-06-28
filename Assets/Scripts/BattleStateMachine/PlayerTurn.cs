using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerTurn : IBattleState
{

    private readonly BattleStatePattern battle;
    GoodGuy player;
    GoodGuy hero1;
    GoodGuy hero2;



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
        if(battle.heroCheck.hero1)
            hero1 = battle.hero1.GetComponent<GoodGuy>();
        if(battle.heroCheck.hero2)
            hero2 = battle.hero2.GetComponent<GoodGuy>();
        if (battle.playerTurn)
        {
            if (battle.playerTurnCount == 1)
            {
                player.RadialMenuCall();
            }
            if (battle.playerTurnCount == 2)
            {
                hero1.RadialMenuCall();  
            }
            if (battle.playerTurnCount == 3)
            {
                hero2.RadialMenuCall();
                    
            }
        }
            

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
        battle.enemyTurn = true;
        if (battle.playerTurnCount == 3)
            battle.playerTurnCount = 1;
        else if (battle.heroCheck.hero1 || battle.heroCheck.hero2)
            battle.playerTurnCount++;

        Debug.Log("Player Turn Count: " + battle.playerTurnCount);
    }

    public void ToBattleWon()
    {
        Debug.Log("Going to Battle Won");
    }

    public void ToBattleLost()
    {

    }

    public void ToBlankState()
    {

    }

}
