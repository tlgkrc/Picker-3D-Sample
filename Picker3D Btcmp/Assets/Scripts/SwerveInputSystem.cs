using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    public bool tap = false;
    public float MoveFactorX => _moveFactorX;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            tap = true;
            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0f;
        }
    }
}
