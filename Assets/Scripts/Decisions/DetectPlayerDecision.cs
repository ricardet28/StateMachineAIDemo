using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/DetectPlayer")]
public class DetectPlayerDecision : Decision {

    public override bool Decide(StateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }

    private bool Look(StateController controller)
    {
        
        RaycastHit hit;
        
        Vector3 startRayPosition = new Vector3(controller.eyes.position.x, 1f, controller.eyes.position.z);
        Vector3 directionRay = new Vector3(controller.eyes.forward.x, 0f, controller.eyes.forward.z);

        Debug.DrawRay(startRayPosition, directionRay.normalized * controller.enemyStats.lookRange, Color.green);

        /*if (controller.chaseTarget != null)
        {
            Vector3 aimPlayer = controller.chaseTarget.position - controller.transform.position;

            if (Mathf.Round(controller.transform.position.y) != 1)
            {
                Debug.DrawRay(controller.eyes.position, aimPlayer.normalized * controller.enemyStats.lookRange, Color.cyan);
            }
        }*/
            

        if (Physics.SphereCast(startRayPosition, controller.enemyStats.lookSphereCastRadius, directionRay, out hit, controller.enemyStats.lookRange)
            && hit.collider.CompareTag("Player")){

            controller.chaseTarget = hit.transform;

            if (controller.sons.Length > 0) //if it has sons / if we are a father
            {
                controller.fatherDetectsPlayer = true;
            }
            return true;

        }
        else
        {
            return false;
        }

        

    }

}
