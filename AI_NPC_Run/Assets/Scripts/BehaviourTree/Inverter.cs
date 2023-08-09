using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

namespace QRun.BehaviorTree
{
    public class Inverter : Node
    {
        Node child;
        public Inverter() : base() { }

        public Inverter(Node child)
        {
            this.child = child;
        }

        public override NodeState Evaluate()
        {
            switch (child.Evaluate())
            {
                case NodeState.Success:
                case NodeState.Running:
                    state = NodeState.Failure;
                    return state;
                case NodeState.Failure:
                    state = NodeState.Success;
                    return state;
            }

            //state = NodeState.Running; 
            return state;
        }
    }
}
