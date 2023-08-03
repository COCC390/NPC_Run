using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpableObstacle : Obstacle
{
    [SerializeField] private Transform _targetTransform;

    public Vector3 GetTargetPoint()
    {
        return new Vector3(_targetTransform.position.x, _targetTransform.position.y + (_targetTransform.lossyScale.y/2), _targetTransform.position.z);
    }
}
