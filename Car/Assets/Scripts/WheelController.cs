using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] private float _breakingForce = 1000f;
    [SerializeField] private float _maxTurnAngle = 30f;
    [SerializeField] private WheelDriveType wheelDriveType;

    private float _currentAcceleration;
    private float _currentBreakingForce;
    private float _currentTurnAngle;

    private void FixedUpdate()
    {
        Breaking();

        AddAcceleration();

        TurnWheels();

        UpdateWheels();
    }

    private void Breaking()
    {
        _currentBreakingForce = ProjectContext.Instance.InputData.IsBreaking ? _breakingForce : 0;

        _wheelControllerFL.brakeTorque = _currentBreakingForce;
        _wheelControllerFR.brakeTorque = _currentBreakingForce;
        _wheelControllerBL.brakeTorque = _currentBreakingForce;
        _wheelControllerBR.brakeTorque = _currentBreakingForce;
    }

    private void AddAcceleration()
    {
        _currentAcceleration = _acceleration * ProjectContext.Instance.InputData.Vertical;

        switch (wheelDriveType)
        {
            case WheelDriveType.Front:
                _wheelControllerFL.motorTorque = _currentAcceleration;
                _wheelControllerFR.motorTorque = _currentAcceleration;
                break;
            case WheelDriveType.Back:
                _wheelControllerBL.motorTorque = _currentAcceleration;
                _wheelControllerBR.motorTorque = _currentAcceleration;
                break;
            case WheelDriveType.All:
                _wheelControllerFL.motorTorque = _currentAcceleration;
                _wheelControllerFR.motorTorque = _currentAcceleration;
                _wheelControllerBL.motorTorque = _currentAcceleration;
                _wheelControllerBR.motorTorque = _currentAcceleration;
                break;
        }
    }

    private void TurnWheels()
    {
        _currentTurnAngle = _maxTurnAngle * ProjectContext.Instance.InputData.Horizontal;

        _wheelControllerFL.steerAngle = _currentTurnAngle;
        _wheelControllerFR.steerAngle = _currentTurnAngle;
    }

    private void UpdateWheels()
    {
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

    private enum WheelDriveType
    {
        Front,
        Back,
        All
    }
}
