using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/FatherDetectingPlayer")]
public class FatherDetectPlayer : Decision {
    //each son will enter here.
    public override bool Decide(StateController controller)
    {
        return fatherDetectsPlayer(controller);
    }

    private bool fatherDetectsPlayer(StateController controller)
    {

        if (controller.father.GetComponent<StateController>().fatherDetectsPlayer)
        {
            Debug.Log("our parent has detected the player.");
            return true;
        }
        return false;

    }

}
