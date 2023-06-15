using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public delegate void OnSwipeInput(Vector2 direction);
    public event OnSwipeInput SwipeEvent;

    [SerializeField] private float _deadZone = 80;

    private Vector2 _startPosition;
    private Vector2 _delta;
    private bool _isSwipe;


    private void Update()
    {
        if (Application.isMobilePlatform)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    _isSwipe = true;
                    _startPosition = Input.GetTouch(0).position;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    CheckSwipe();
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    ResetSwipe();
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isSwipe = true;
                _startPosition = Input.GetTouch(0).position;
            }
            else if (Input.GetMouseButton(0))
            {
                CheckSwipe();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                ResetSwipe();
            }
        }
    }

    private void CheckSwipe()
    {
        if (_isSwipe)
        {
            if (Application.isMobilePlatform)
            {
                _delta = Input.GetTouch(0).position - _startPosition;
            }
            else
            {
                _delta = (Vector2)Input.mousePosition - _startPosition;
            }

            if (_delta.sqrMagnitude > _deadZone * _deadZone)
            {
                if (SwipeEvent != null)
                {
                    if (Math.Abs(_delta.x) > Math.Abs(_delta.y))
                    {
                        SwipeEvent(_delta.x > 0 ? Vector2.right : Vector2.left);
                    }
                    else
                    {
                        SwipeEvent(_delta.y > 0 ? Vector2.up : Vector2.down);
                    }
                }

                ResetSwipe();
            }
        }
    }

    private void ResetSwipe()
    {
        _startPosition = Vector2.zero;
        _delta = Vector2.zero;

        _isSwipe = false;
    }
}
