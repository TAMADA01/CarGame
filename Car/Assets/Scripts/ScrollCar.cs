using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScrollCar : MonoBehaviour
{
    [SerializeField] private Transform _content;

    [SerializeField] private Button _leftArrow;
    [SerializeField] private Button _rightArrow;

    private int _index = 0;
    private GameObject _car;
    private List<GameObject> _cars => ProjectContext.Instance.GameData.Cars;

    public int Index 
    { 
        get => _index;
        set
        { 
            _index = value;
            ChangeCar(value);

            if (value == 0)
            {
                _leftArrow.gameObject.SetActive(false);
                _rightArrow.gameObject.SetActive(true);
            }
            else if (value == _cars.Count - 1)
            {
                _leftArrow.gameObject.SetActive(true);
                _rightArrow.gameObject.SetActive(false);
            }
            else
            {
                _leftArrow.gameObject.SetActive(true);
                _rightArrow.gameObject.SetActive(true);
            }
        }
    }

    private void Start()
    {
        _leftArrow.gameObject.SetActive(false);
        _rightArrow.gameObject.SetActive(true);

        ChangeCar(Index);

        ProjectContext.Instance.SwipeDetection.SwipeEvent += OnSwipe;
    }

    private void OnSwipe(Vector2 direction)
    {
        if (direction == Vector2.right && Index > 0)
        {
            Index--;
        }
        else if (direction == Vector2.left && Index < _cars.Count - 1)
        {
            Index++;
        }
    }

    private void ChangeCar(int index)
    {
        var car = Instantiate(_cars[index], _content.position, new Quaternion(0, 0, 0, 0), _content);
        car.GetComponent<Rigidbody>().useGravity = false;
        car.GetComponent<WheelController>().enabled = false;

        Destroy(_car);
        _car = car;
    }

    public void SetCurrentCar()
    {
        ProjectContext.Instance.GameData.SetCurrentCar(Index);
        ProjectContext.Instance.SwipeDetection.SwipeEvent -= OnSwipe;
    }

    public void OnNextCar()
    {
        Index++;
    }

    public void OnPrevCar()
    {
        Index--;
    }
}
