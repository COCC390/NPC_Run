using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSensorController : MonoBehaviour // rename to npc sensor controller
{
    [SerializeField] private Transform _endPoint;
    [SerializeField] private List<Sensor> _sensors;

    [SerializeField] private float _timeToNextScan = 3f;

    private bool _scanable = true;
    public bool walkable = true;

    [Header("Scan result")]
    public Vector3 sensorDirection;
    public ObstacleType stuckByObstacleType;
    public GameObject obstacle;

    public Action EnableForSensorScan;

    #region Unity Default Method
    private void Start()
    {
        StartCoroutine(SensorScan()); // switch this to another function to easy modified the time when we need to start scan

        EnableForSensorScan += EnableSensor;
    }
    #endregion

    private IEnumerator SensorScan()
    {
        while(_scanable)
        {
            foreach(Sensor sensor in _sensors)
            {
                walkable = sensor.SensorScan();
                if(walkable)
                {
                    sensorDirection = sensor.GetSensorDirection();
                    break;
                }
                else
                {
                    stuckByObstacleType = sensor.GetTypeOfObstacle();

                    if (stuckByObstacleType != ObstacleType.NotWalkableObstacle)
                    {
                        obstacle = sensor.GetObstacleObject();
                        _scanable = false;
                        break;
                    }
                }
            }

            yield return new WaitForSeconds(_timeToNextScan);
        }
    }

    private void EnableSensor() {
        _scanable = true;
        StartCoroutine(SensorScan());
    }

    public void SensorStopWorking() {
        EnableForSensorScan -= EnableSensor;
        StopAllCoroutines();
    }
}
