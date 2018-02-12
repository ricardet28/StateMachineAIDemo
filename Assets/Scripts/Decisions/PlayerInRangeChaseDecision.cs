﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/PlayerInRangeChase")]
public class PlayerInRangeChaseDecision : Decision {

    public override bool Decide(StateController controller)
    {
        bool isThePlayerInRange = PlayerInRange(controller);
        return isThePlayerInRange;
    }

    public bool PlayerInRange(StateController controller)
    {
        float distance = Vector3.Distance(controller.eyes.position, controller.chaseTarget.position);
        if (distance > controller.enemyStats.maxDistanceChase)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}