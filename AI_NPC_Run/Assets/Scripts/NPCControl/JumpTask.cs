using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QRun.BehaviorTree;

public class JumpTask : Node 
{
    private const float DISTANCETOJUMP = 40f;
    
    private NPCController _npcController;
    private Transform _npcTransform;
    private Rigidbody _npcRigidbody;
    private NPCSensorController _npcSensorController;

    public JumpTask(NPCController npcController, Transform npcTransform, Rigidbody npcRigidBody, NPCSensorController npcSensorController) {
        _npcController = npcController;
        _npcTransform = npcTransform;
        _npcRigidbody = npcRigidBody;
        _npcSensorController = npcSensorController;
    }

    public override NodeState Evaluate() {
        if (_npcSensorController.stuckByObstacleType == ObstacleType.JumpableObstacle)
        {
            if (Vector3.Distance(_npcSensorController.obstacle.transform.position, _npcTransform.position) >= DISTANCETOJUMP && !_npcController.isJumping)
                _npcTransform.position += (_npcSensorController.obstacle.transform.position - _npcTransform.position).normalized * _npcController.RunSpeed * Time.deltaTime;
            else if(!_npcController.isJumping)
            {
                DoJump();
                _npcController.isJumping = true;

                state = NodeState.Success;
                return state;
            }

            state = NodeState.Running;
            return state;
        }

        state = NodeState.Failure;
        return state;
    }


    private void DoJump() 
    {
        Debug.Log("Do jump ");
        float jumpVelocity = Mathf.Sqrt(2 * 9.8f * _npcController.JumpHeight);

        Vector3 jumpDirection = (_npcSensorController.obstacle.transform.position - _npcTransform.position).normalized;

        Vector3 forceVector = new Vector3(jumpDirection.x * _npcController.HorizontalVelocity, jumpVelocity, jumpDirection.z * _npcController.HorizontalVelocity);

        _npcRigidbody.AddForce(forceVector, ForceMode.Impulse);
    }
}