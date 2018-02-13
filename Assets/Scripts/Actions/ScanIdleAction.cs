using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/ScanIdle")]
public class ScanIdleAction : Action {

    public override void Act(StateController controller)
    {
        TurnAndScan(controller);
    }

    private void TurnAndScan(StateController controller)
    {
        controller.gameObject.transform.Rotate(0, controller.enemyStats.searchingTurnSpeed * Time.deltaTime, 0);
    }
}
