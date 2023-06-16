using UnityEngine;
using Cinemachine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    private GameObject _carPrefab => ProjectContext.Instance.GameData.CarPrefab;
    private GameObject _car;
    private void Awake()
    {
        _car = Instantiate(_carPrefab, transform.position, transform.rotation);

        _camera.Follow = _car.transform;
        _camera.LookAt = _car.transform;
    }

    public void Restart()
    {
        var car = Instantiate(_carPrefab, transform.position, transform.rotation);

        _camera.Follow = car.transform;
        _camera.LookAt = car.transform;

        Destroy(_car);
        _car = car;
    }
}
