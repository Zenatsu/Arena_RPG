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

    void start()
    {
        spawn.SpawnSystem(battle.spawnGoodGuy, battle.SpawnBadGuy);
        ToPlayerTurn();
    }

    public void ToStartCombat()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToPlayerTurn()
    {
        battle.currentState = battle.playerTurnState;
        battle.playerTurn = true;
        battle.heroTurn = true;
        battle.playerTurnCount = 1;
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

    }

}
