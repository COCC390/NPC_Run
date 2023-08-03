using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QRun.BehaviorTree;

public class WaitingTask : Node
{
    private QRunGameController _qRunGameController;

    public WaitingTask(QRunGameController qRunGameController)
    {
        _qRunGameController = qRunGameController;
    }

    public override NodeState Evaluate()
    {
        if(!_qRunGameController.isStart)
        {
            Debug.Log("wait for start");
            state = NodeState.Success;
            return state;
        }

        //Debug.Log("runnnnnnn...");
        state = NodeState.Failure;
        return state;
    }
}
