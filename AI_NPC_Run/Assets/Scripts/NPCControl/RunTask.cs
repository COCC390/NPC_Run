using QRun.BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunTask : Node
{
    private Transform _npcTransform;

    private NPCController _npcController;
    private NPCSensorController _sensor;

    public RunTask(Transform npcTransform, NPCController npcController, NPCSensorController sensor)
    {
        _npcTransform = npcTransform;
        _npcController = npcController;
        _sensor = sensor;
    }

    public override NodeState Evaluate()
    {
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
        Debug.Log("run task");

        // write function for make character run follow the ray direction
        _npcTransform.position += _sensor.sensorDirection * _npcController.RunSpeed * Time.deltaTime;

        state = NodeState.Running;
        return state;
    }
}
