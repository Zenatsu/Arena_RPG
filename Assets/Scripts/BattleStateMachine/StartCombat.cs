using UnityEngine;
using System.Collections;
using System;

public class StartCombat : IBattleState {

    private BattleStatePattern battle;
    Spawner spawn;
    GoodGuy player;
    BadGuy enemy;

    //player pos
    Vector3 gPos1 = new Vector3(-6, 0, 0);

    //enemy pos
    Vector3 bPos1 = new Vector3(3, 1, 0);

    public StartCombat(BattleStatePattern battleStatePattern)
    {
        battle = battleStatePattern;
        spawn = GameObject.Find("ScriptManager").GetComponent<Spawner>();
    }

    public void UpdateState()
    {
        start();
    }

    public void ToStartCombat()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToPlayerTurn()
    {
        battle.currentState = battle.playerTurnState;
        battle.playerTurn = true;
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

    void start()
    {
        spawn.SpawnSystem(battle.spawnGoodGuy, battle.SpawnBadGuy);
        
        /*
        player = battle.spawnGoodGuy.GetComponent<GoodGuy>();
        enemy = battle.badGuy.GetComponent<BadGuy>();
        //spawn player
        GameObject spawnPlayer = GameObject.Instantiate(player, gPos1, Quaternion.identity) as GameObject;
        battle.goodGuy = GameObject.FindGameObjectWithTag("Player");
        //spawn enemy
        GameObject spawnEnemy = GameObject.Instantiate(enemy, bPos1, Quaternion.identity) as GameObject;
        //transistion to Player Turn
        */
        ToPlayerTurn();
    }
}
