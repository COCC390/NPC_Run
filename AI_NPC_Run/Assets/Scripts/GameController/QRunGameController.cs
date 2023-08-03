using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QRunGameController : MonoBehaviour
{
    [Header("GameRule")]
    [SerializeField] private GameObject _startObject;
    [SerializeField] private GameObject _stopObject;

    [SerializeField] private float _startTime = 3f;
    public bool isStart = false;

    private void Start()
    {
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(_startTime);

        Debug.Log("start");
        isStart = true;
    }
}
