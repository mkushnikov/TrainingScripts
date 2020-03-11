using System;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [SerializeField] private GameObject _myCircle;

    [SerializeField] private List<Vector3> _movementOrder = new List<Vector3>();

    private LineRenderer _myLinesDrawer;

    private void Awake()
    {
        _myLinesDrawer = GetComponent<LineRenderer>();
        _myLinesDrawer.material.color = Color.black;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0;

            _movementOrder.Add(clickPosition);
        }

        if (_movementOrder.Count != 0)
        {
            if (IsTargetReached(_movementOrder[0]) == false)
            {
                _myCircle.GetComponent<MyLittleCircle>().MoveToTarget(_movementOrder[0]);
                DrawLine(_movementOrder[0]);
            }
            else
            {
                _movementOrder.Remove(_movementOrder[0]);
            }
        }
    }

    private void DrawLine(Vector3 targetPoint)
    {
        _myLinesDrawer.SetPosition(0, _myCircle.transform.position);
        _myLinesDrawer.SetPosition(1, targetPoint);
    }

    private bool IsTargetReached(Vector3 targetPoint)
    {
        return _myCircle.transform.position == targetPoint;
    }
}
