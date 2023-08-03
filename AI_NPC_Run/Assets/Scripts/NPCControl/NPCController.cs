using UnityEngine;
using QRun.BehaviorTree;
using System.Collections.Generic;
using UnityEngine.AI;

public class NPCController : QRun.BehaviorTree.Tree
{
    [SerializeField] private RunGameController _runGameController;

    [SerializeField] private NPCSensor _npcSensor;

    [Header("For Run")]
    [SerializeField] private float _runSpeed = 1f;
    [SerializeField] private float _boostSpeed = 10f;

    [Header("For Jump")]
    [SerializeField] private float _jumpHeight = 10f;
    [SerializeField] private float _jumpAngle = 60f;

    public float JumpHeight { get => _jumpHeight; set => _jumpHeight = value; }
    public float JumpAngle { get => _jumpAngle; set => _jumpAngle = value; }

    [Header("For End Run")]
    public bool isOnGoal = false;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new EndRunTask(this),
            new WaitingTask(_runGameController),
            new Selector(new List<Node>
            {
                new RunTask(transform, _runSpeed, this, _npcSensor),
                new JumpTask(this, transform, this.GetComponent<Rigidbody>(), _npcSensor),
            })
        });
        return root;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider name: " + other.gameObject.name);

        switch(other.gameObject.name)
        {
            case "Stop":
                isOnGoal = true;
                break;
            //case "Jump":
            //    onJumpTrigger = true;
            //    break;
        }
    }
}
