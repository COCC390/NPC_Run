using QRun.BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunTask : Node
{
    private Transform _npcTransform;
    private float _runSpeed;

    // for stop running state
    private NPCController _npcController;
    private NPCSensor _sensor;

    public RunTask(Transform npcTransform, float runSpeed, NPCController npcController, NPCSensor sensor)
    {
        _npcTransform = npcTransform;
        _runSpeed = runSpeed;
        _npcController = npcController;
        _sensor = sensor;
    }

    public override NodeState Evaluate()
    {
        Debug.Log("run task");
        //_npcTransform.Translate(Vector3.forward * _runSpeed * Time.deltaTime);
        if(_npcController.isOnGoal)
        {
            state = NodeState.Success;
            return state;
        }

        // create a condition to check failure for jump or do somethings special
        if(!_sensor.walkable)
        {
            state = NodeState.Failure;
            return state;
        }

        // write function for make character run follow the ray direction
        Debug.Log("run task");
        _npcTransform.position += _sensor.sensorDirection * _runSpeed * Time.deltaTime;

        state = NodeState.Running;
        return state;
    }
}
