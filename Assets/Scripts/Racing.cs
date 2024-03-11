﻿using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Racing : MonoBehaviour
{
    [SerializeField] private GameObject enemyCar;
    [SerializeField] private GameObject playerCar;
    
    [SerializeField] private GameObject finish;
    [SerializeField] private Image result;

    private Vector3 pos;
    private bool ongoing;

    private void Start()
    {
        finish.SetActive(false);
    }

    public void Initialize()
    {
        finish.SetActive(false);
        pos = transform.position;
        ongoing = true;
    }

    private void Update()
    {
        if (!ongoing)
        {
            return;
        }

        transform.position -= Vector3.right * Time.deltaTime * 30;

        if (transform.position.x <= -50)
        {
            transform.position = pos - (Vector3.left * 50);
        }
    }

    public void MoveCar(CarType type)
    {
        if (type == CarType.Player)
        {
            playerCar.transform.DOLocalMove(playerCar.transform.localPosition + (Vector3.left * 2), 1f);
        }
        else
        {
            enemyCar.transform.DOLocalMove(enemyCar.transform.localPosition + (Vector3.left * 2),1f);
        }
    }

    public void Finish()
    {
        ongoing = false;
        ScreenManager.instance.OpenScreen(5);
        transform.position = pos - (Vector3.left * 50);
        finish.SetActive(true);

        Sequence sq = DOTween.Sequence();
        sq.Append(transform.DOMoveX(finish.transform.position.x, 2f).SetEase(Ease.Linear));
        sq.AppendCallback(() => result.DOFade(1, 0.5f));
        sq.Append(transform.DOMoveX(finish.transform.position.x - 20, 1f).SetEase(Ease.OutQuart));
    }
}

public enum CarType
{
    Player = 0,
    Enemy = 1,
}