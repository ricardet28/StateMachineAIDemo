using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Shoot")]
public class ShootAction : Action
{
    private float currentTimer = 0f;
    public override void Act(StateController controller)
    {
        ShootPlayer(controller);
    }

    private void ShootPlayer(StateController controller)
    {

        Vector3 direction = controller.chaseTarget.position - controller.transform.position;
        direction.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        controller.transform.rotation = Quaternion.Lerp(controller.transform.rotation, targetRotation, 4f * Time.deltaTime);

        RaycastHit hit;
        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.enemyStats.attackRange, Color.red);

        if (Physics.SphereCast(controller.eyes.position, controller.enemyStats.lookSphereCastRadius, controller.eyes.forward, out hit, controller.enemyStats.attackRange)
            && hit.collider.CompareTag("Player"))
        {
            if (controller.checkIfCountDownElapsed(controller.enemyStats.attackRate))
            {
                Rigidbody projectileInstance = (Rigidbody)Instantiate(controller.projectile, controller.firePosition.position, controller.firePosition.rotation);
                projectileInstance.velocity = Vector3.Distance(controller.transform.position, controller.chaseTarget.position) * controller.enemyStats.attackForce * controller.firePosition.forward;
                controller.stateTimeElapsed = 0f;
                
            }
        }
    }

}
