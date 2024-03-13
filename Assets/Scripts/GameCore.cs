using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameCore : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
        DOTween.Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ScreenManager.instance.GoBack();
        }
    }
}
