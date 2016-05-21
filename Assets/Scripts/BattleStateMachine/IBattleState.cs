﻿using UnityEngine;
using System.Collections;

public interface IBattleState
{
    //Interface to set up states

    void UpdateState();

    void ToStartCombat();

    void ToPlayerTurn();

    void ToEnemyTurn();

    void ToBattleWon();

    void ToBattleLost();
}
