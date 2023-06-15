using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRotation : MonoBehaviour
{
    [SerializeField] private Vector3 _vector = Vector3.up;
    [SerializeField] private float _speed = 20;

    private void Update()
    {
        var rotate = transform.eulerAngles;
        rotate += _vector * _speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotate);
    }
}
