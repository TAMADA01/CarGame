using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] private WheelCollider _wheelControllerFR;
    [SerializeField] private WheelCollider _wheelControllerFL;
    [SerializeField] private WheelCollider _wheelControllerBR;
    [SerializeField] private WheelCollider _wheelControllerBL;

    [SerializeField] private Transform _wheelTransformFR;
    [SerializeField] private Transform _wheelTransformFL;
    [SerializeField] private Transform _wheelTransformBR;
    [SerializeField] private Transform _wheelTransformBL;

    [SerializeField] private float _acceleration = 500f;
    [SerializeField] private float _maxTurnAngle = 20f;

    private float _currentAcceleration;
    private float _currentTurnAngle;

    private void FixedUpdate()
    {
        _currentAcceleration = _acceleration * ProjectContext.Instance.InputData.Vertical;

        _wheelControllerBL.motorTorque = _currentAcceleration;
        _wheelControllerBR.motorTorque = _currentAcceleration;

        _currentTurnAngle = _maxTurnAngle * ProjectContext.Instance.InputData.Horizontal;

        _wheelControllerFL.steerAngle = _currentTurnAngle;
        _wheelControllerFR.steerAngle = _currentTurnAngle;

        UpdateWheel(_wheelControllerFR, _wheelTransformFR);
        UpdateWheel(_wheelControllerFL, _wheelTransformFL);
        UpdateWheel(_wheelControllerBR, _wheelTransformBR);
        UpdateWheel(_wheelControllerBL, _wheelTransformBL);
    }

    private void UpdateWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 position;
        Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);

        wheelTransform.position = position;
        wheelTransform.rotation = rotation;
    }
}
