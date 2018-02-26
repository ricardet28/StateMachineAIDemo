using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/WaitAiming")]
public class WaitingAimingAction : Action {

    public override void Act(StateController controller)
    {
        aimToPlayer(controller);
    }

    private void aimToPlayer(StateController controller)
    {

        controller.eyes.transform.LookAt(controller.chaseTarget);//aim to the player
        Vector3 direction = controller.chaseTarget.position - controller.transform.position;
        Debug.DrawRay(controller.gameObject.transform.position, direction.normalized * controller.enemyStats.lookRange, Color.cyan);
    }


}
