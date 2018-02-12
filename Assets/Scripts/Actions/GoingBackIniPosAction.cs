using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/GoingBackInitialPosition")]
public class GoingBackIniPosAction : Action {

    public override void Act(StateController controller)
    {
        GoBackInitialPos(controller);
    }

    private void GoBackInitialPos(StateController controller)
    {
        controller.navMeshAgent.destination = controller.initialPosition;
        controller.navMeshAgent.isStopped = false;
    }

}
