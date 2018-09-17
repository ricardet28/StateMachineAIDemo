using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : ActionAI {

    public override void Act(StateController controller)
    {
        ChasePlayer(controller);
    }
    private void ChasePlayer(StateController controller)
    {
        
        controller.navMeshAgent.destination = controller.chaseTarget.position;
        controller.navMeshAgent.isStopped = false;
    }

}
