using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EnemyTurn : IBattleState
{
    private readonly BattleStatePattern battle;
    BadGuy badGuy;
    BadGuy badGuy2;
    BadGuy badGuy3;
    BadGuyTarget badGuyTarget;

    int caseSwitch;

    public EnemyTurn(BattleStatePattern battleStatePattern)
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
        if (battle.enemy2Spawned)
            badGuy2 = battle.badGuy2.GetComponent<BadGuy>();
        if (battle.enemy3Spawned)
            badGuy3 = battle.badGuy3.GetComponent<BadGuy>();

        badGuyTarget = battle.badGuy.GetComponent<BadGuyTarget>();

        if (battle.enemy1Turn)
        {
            badGuy.badGuyAnim();
            //battle.enemy1Turn = false;
            if (badGuy.finishedFlashing == true)
                AttackPlayer();
        }

        if (battle.enemy2Turn)
        {
            badGuy2.badGuyAnim();
            //battle.enemy2Turn = false;
            if (badGuy2.finishedFlashing == true)
                AttackPlayer();
        }

        if (battle.enemy3Turn)
        {
            badGuy3.badGuyAnim();
            //battle.enemy3Turn = false;
            if (badGuy3.finishedFlashing == true)
                AttackPlayer();
        }

    }
    public void AttackPlayer() //make a way to have badguys send their attack value
    {
        caseSwitch = Random.Range(Mathf.RoundToInt(1f), Mathf.RoundToInt(3f));
        switch (caseSwitch)
        {
            case 1:
                Debug.Log("Using Basic Attack");
                badGuyTarget.SelectTarget();
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
                badGuyTarget.SelectTarget();
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
                badGuyTarget.SelectTarget();
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

        EnemyBattleCounter(battle.enemy1Spawned, battle.enemy2Spawned, battle.enemy3Spawned);

        if (battle.playerTurnCount == 1)
            battle.heroTurn = true;
        if (battle.playerTurnCount == 2)
            battle.hero1Turn = true;
        if (battle.playerTurnCount == 3)
            battle.hero2Turn = true;

        battle.enemyTurn = false;
        battle.enemy1Turn = false;
        battle.enemy2Turn = false;
        battle.enemy3Turn = false;

        battle.currentState = battle.playerTurnState;
    }

    private void EnemyBattleCounter(bool spawned1, bool spawned2, bool spawned3)
    {
        if (spawned3)
        {
            if (battle.enemyTurnCount == 3)
                battle.enemyTurnCount = 1;
            else
                battle.enemyTurnCount++;
        }
        else if (spawned2)
        {
            if (battle.enemyTurnCount == 2)
                battle.enemyTurnCount = 1;
            else
                battle.enemyTurnCount++;
        }
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
