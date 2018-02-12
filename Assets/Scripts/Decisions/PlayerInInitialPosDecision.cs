using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "PluggableAI/Decisions/PlayerInInitialPosition")]
public class PlayerInInitialPosDecision : Decision {

    public override bool Decide(StateController controller)
    {
        return CheckIfPlayerIsInInitialPosition(controller);
    }

    private bool CheckIfPlayerIsInInitialPosition(StateController controller)
    {
        //Debug.Log("MyPosition: " + controller.transform.position);
        //Debug.Log("ObjPosition: " + controller.initialPosition);
 
        if (Mathf.Round(controller.transform.position.x) == Mathf.Round(controller.initialPosition.x) && Mathf.Round(controller.transform.position.z) == Mathf.Round(controller.initialPosition.z))
        {
            return true;
        }
        return false;
        
    }
}
