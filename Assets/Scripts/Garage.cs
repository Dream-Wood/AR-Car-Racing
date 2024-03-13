using System;
using System.Collections.Generic;
using UnityEngine;

public class Garage: MonoBehaviour
{
    [SerializeField] private List<CarEngine> cars;
    private int last;

    private void Start()
    {
        foreach (var t in cars)
        {
            t.gameObject.SetActive(false);
        }

        SelectCar(0);
    }

    public int GetCarsCount()
    {
        return cars.Count;
    }

    public string SelectCar(int id)
    {
        if (id >= cars.Count)
        {
            return "null";
        }
        
        cars[last].gameObject.SetActive(false);
        cars[id].gameObject.SetActive(true);

        last = id;

        return cars[id].CarName;
    }
}