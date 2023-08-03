using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QRun.BehaviorTree;

public class JumpTask : Node
{
    private NPCController _npcController;
    private Transform _npcTransform;
    private Rigidbody _npcRigidbody;
    private NPCSensor _npcSensorController;

    public JumpTask(NPCController npcController, Transform npcTransform, Rigidbody npcRigidBody, NPCSensor npcSensorController)
    { 
        _npcController = npcController;
        _npcTransform = npcTransform;
        _npcRigidbody = npcRigidBody;
        _npcSensorController = npcSensorController;
    }

    public override NodeState Evaluate()
    {
        if(_npcSensorController.stuckByObstacleType == ObstacleType.JumpableObstacle)
        {
            // Do Jump
            Debug.Log("Do jump " + CalculateVelocity());



            state = NodeState.Success;
            return state;
        }

        state = NodeState.Failure;
        return state;
    }

    private void DoJump()
    {
        //_npcRigidbody.velocity = CalculateVelocity();
    }

    private float CalculateVelocity()
    {
        float A = (_npcController.JumpHeight + _npcTransform.position.magnitude + Mathf.Tan(_npcController.JumpAngle) - (9.8f * _npcTransform.position.sqrMagnitude)) / _npcSensorController.obstacle.transform.position.magnitude;
        float B = A / Mathf.Cos(_npcController.JumpAngle);
        return Mathf.Sqrt(B / 2);
    }
}
