using System.Collections;
using UnityEngine;
using System;

public class Sensor : MonoBehaviour
{
    [Header("Sensor Management")]
    [SerializeField] private NPCSensor _npcSensorManage;

    [Header("Raycast For Sensor")]
    [SerializeField] private Color _sensorRayColor = Color.green;
    [SerializeField] private Vector3 _sensorPoint;
    [SerializeField] private Transform _npcTransform;
    [SerializeField] private float _sensorScanDistance = 10f;
    private Vector3 _virtualPoint;

    private RaycastHit _hit;

    private int _raycastLayerMask;

    #region Unity Default 
    void Start()
    {
        _raycastLayerMask = LayerMask.GetMask("Obstacles", "QRunPlayer");
    }

    #endregion

    #region Scan
    public bool SensorScan()
    {
        bool isWalkable = true;
        
        if (Physics.Raycast(_npcTransform.position, _sensorPoint, out _hit, _sensorScanDistance, _raycastLayerMask))
        {
            isWalkable = false;
            _sensorRayColor = Color.red;
        }
        else 
        {
            _sensorRayColor = Color.green;
            isWalkable = true;
        }

        return isWalkable;
    }
    #endregion

    #region Get Result
    public ObstacleType GetTypeOfObstacle()
    {
        return _hit.collider.gameObject.GetComponent<Obstacle>().GetObstacleType;
    }

    public GameObject GetObstacleObject()
    {
        return _hit.collider.gameObject;
    }

    public Vector3 GetSensorDirection()
    {
        _virtualPoint = _npcTransform.position + _sensorPoint;
        Vector3 sensorDirection = _virtualPoint - _npcTransform.position;

        return sensorDirection;
    }
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = _sensorRayColor;

        Gizmos.DrawRay(_npcTransform.position, _sensorPoint * _sensorScanDistance);
    }
}
