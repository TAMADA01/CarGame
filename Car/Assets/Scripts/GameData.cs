using System;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public GameObject CarPrefab;

    public List<GameObject> Cars;

    public void SetCurrentCar(int index)
    {
        CarPrefab = Cars[index];
    }
}
