using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType
{
    Default,
    NotWalkableObstacle,
    JumpableObstacle,
}

public class Obstacle : MonoBehaviour
{
    [SerializeField] private ObstacleType _obstacleType;    

    public ObstacleType GetObstacleType { get => _obstacleType; }

    protected virtual void ObstacleBehavior()
    {
        // override if obstacle have behavior
    }
}
