using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Shoot")]
public class ShootAction : ActionAI
{
    private float currentTimer = 0f;
    public override void Act(StateController controller)
    {
        ShootPlayer(controller);
    }

    private void ShootPlayer(StateController controller)
    {
        Vector3 aimPlayer = controller.chaseTarget.position - controller.transform.position;

        Vector3 direction = controller.chaseTarget.position - controller.transform.position;
        direction.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        controller.transform.rotation = Quaternion.Lerp(controller.transform.rotation, targetRotation, 4f * Time.deltaTime);

        RaycastHit hit;
        Vector3 startRayPosition = new Vector3(controller.eyes.position.x, 1f, controller.eyes.position.z);
        Vector3 directionRay = new Vector3(controller.eyes.forward.x, 0f, controller.eyes.forward.z);
        Debug.DrawRay(startRayPosition, directionRay.normalized * controller.enemyStats.attackRange, Color.red);
        
        //if (controller.chaseTarget != null)
        //{
            //Vector3 aimPlayer = controller.chaseTarget.position - controller.transform.position;

            if (Mathf.Round(controller.transform.position.y) != 1)
            {
                Debug.DrawRay(controller.eyes.position, aimPlayer.normalized * controller.enemyStats.lookRange, Color.cyan);
            }
        //}


        if (Physics.SphereCast(startRayPosition, controller.enemyStats.lookSphereCastRadius, directionRay, out hit, controller.enemyStats.attackRange)
            && hit.collider.CompareTag("Player"))
        {
            if (controller.checkIfCountDownElapsed(controller.enemyStats.attackRate))
            {
                Rigidbody projectileInstance = (Rigidbody)Instantiate(controller.projectile, controller.firePosition.position, controller.eyes.rotation);
                //projectileInstance.velocity = Vector3.Distance(controller.transform.position, controller.chaseTarget.position) * controller.enemyStats.attackForce * controller.firePosition.forward;
                projectileInstance.velocity = Vector3.Distance(controller.transform.position, controller.chaseTarget.position) * controller.enemyStats.attackForce * aimPlayer.normalized;
                controller.stateTimeElapsed = 0f;
                
            }
        }

    }

}
