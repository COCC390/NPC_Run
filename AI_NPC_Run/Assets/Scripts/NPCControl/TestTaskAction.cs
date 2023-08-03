using QRun.BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTaskAction : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _autoMoveSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        if(_rb == null)
            _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Translate(Vector3.forward * _autoMoveSpeed * Time.deltaTime);

    }
}
