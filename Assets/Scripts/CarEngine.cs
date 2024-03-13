using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    public String CarName;
    [SerializeField] private Transform axisA;
    [SerializeField] private Transform axisB;

    private bool engineStart;

    private void Update()
    {
        if (!engineStart)
        {
            return;
        }
        
        axisA.Rotate(Vector3.back, 30);
        axisB.Rotate(Vector3.back, 30);
    }

    public void StartEngine()
    {
        engineStart = true;
    }
    
    public void StopEngine()
    {
        engineStart = false;
    }
}
