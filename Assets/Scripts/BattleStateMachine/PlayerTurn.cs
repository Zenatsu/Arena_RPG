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
        if (battle.playerTurnCount == 3)
            battle.playerTurnCount = 1;
        else if (battle.heroCheck.hero1 || battle.heroCheck.hero2)
            battle.playerTurnCount++;

        if (battle.enemyTurnCount == 1)
            battle.enemy1Turn = true;
        if (battle.enemyTurnCount == 2)
            battle.enemy2Turn = true;
        if (battle.enemyTurnCount == 3)
            battle.enemy3Turn = true;

        battle.enemyTurn = true;



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
