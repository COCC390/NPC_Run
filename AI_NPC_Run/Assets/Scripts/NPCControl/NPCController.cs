using UnityEngine;
using QRun.BehaviorTree;
using System.Collections.Generic;
using UnityEngine.AI;

public class NPCController : QRun.BehaviorTree.Tree
{
    [SerializeField] private RunGameController _runGameController;

    [SerializeField] private NPCSensorController _npcSensor;

    [Header("For Run")]
    [SerializeField] private float _runSpeed = 1f;
    [SerializeField] private float _boostSpeed = 10f;

    public float RunSpeed { get => _runSpeed; set => _runSpeed = value; }

    [Header("For Jump")]
    [SerializeField] private float _jumpHeight = 10f;
    [SerializeField] private float _horizontalVelocity = 10f;
    public bool isJumping = false;

    public float JumpHeight { get => _jumpHeight; }
    public float HorizontalVelocity { get => _horizontalVelocity; }

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
                new RunTask(transform, this, _npcSensor),
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
                _npcSensor.SensorStopWorking();
                break;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        switch (collision.collider.tag) 
        {
            case "Ground":
                isJumping = false;
                _npcSensor.EnableForSensorScan?.Invoke();
                break;
        }
    }
}
