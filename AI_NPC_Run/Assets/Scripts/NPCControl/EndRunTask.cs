using QRun.BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRunTask : Node
{
    private NPCController _npcController;

    public EndRunTask(NPCController npcController)
    {
        _npcController = npcController;
    }

    public override NodeState Evaluate()
    {
        Debug.Log(_npcController.isOnGoal);
        if (_npcController.isOnGoal)
        {
            state = NodeState.Success;
            return state;
        }

        state = NodeState.Failure;
        return state;
    }
}
