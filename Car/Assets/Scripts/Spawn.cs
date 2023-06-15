using UnityEngine;
using Cinemachine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    private GameObject _car => ProjectContext.Instance.GameData.CarPrefab;
    private void Awake()
    {
        var car = Instantiate(_car, transform.position, transform.rotation);

        _camera.Follow = car.transform;
        _camera.LookAt = car.transform;
    }
}
