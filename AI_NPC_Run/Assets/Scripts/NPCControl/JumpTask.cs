using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QRun.BehaviorTree;

public class JumpTask : Node {
    private NPCController _npcController;
    private Transform _npcTransform;
    private Rigidbody _npcRigidbody;
    private NPCSensor _npcSensorController;

    public JumpTask(NPCController npcController, Transform npcTransform, Rigidbody npcRigidBody, NPCSensor npcSensorController) {
        _npcController = npcController;
        _npcTransform = npcTransform;
        _npcRigidbody = npcRigidBody;
        _npcSensorController = npcSensorController;
    }

    public override NodeState Evaluate() {
        if (_npcSensorController.stuckByObstacleType == ObstacleType.JumpableObstacle) {
            // Do Jump
            Debug.Log("Do jump ");
            _npcTransform.LookAt(_npcSensorController.obstacle.transform);

            float jumpVelocity = Mathf.Sqrt(2 * 9.8f * _npcController.JumpHeight);
            Vector3 jumpDirection = (_npcSensorController.obstacle.transform.position - _npcTransform.position).normalized;

            _npcRigidbody.velocity = new Vector3(jumpDirection.x * 20f, jumpVelocity, jumpDirection.z * 20f);

            state = NodeState.Success;
            return state;
        }

        state = NodeState.Failure;
        return state;
    }

}