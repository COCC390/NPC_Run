using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QRun.BehaviorTree;

public class WaitingTask : Node
{
    private RunGameController _runGameController;

    public WaitingTask(RunGameController runGameController)
    {
        _runGameController = runGameController;
    }

    public override NodeState Evaluate()
    {
        if(!_runGameController.isStart)
        {
            Debug.Log("wait for start");
            state = NodeState.Success;
            return state;
        }

        state = NodeState.Failure;
        return state;
    }
}
