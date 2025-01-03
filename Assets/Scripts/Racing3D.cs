﻿using System;
using Data;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Racing3D : Racing
{
    [SerializeField] private GameObject enemyCar;
    [SerializeField] private CarEngine enemyCarEngine;
    [SerializeField] private GameObject playerCar;
    [SerializeField] private CarEngine playerCarEngine;
    [SerializeField] private ParticleSystem aitStream;
    
    [SerializeField] private GameObject finish;
    [SerializeField] private Image result;
    
    [SerializeField] private Garage garage;

    private Vector3 pos;
    private bool ongoing;

    private void Start()
    {
        finish.SetActive(false);
        pos = transform.position;
        aitStream.Stop();
    }

    public override void PreInitialize()
    {
        if (enemyCar != null)
        {
            Destroy(enemyCarEngine.gameObject);
        }
        enemyCarEngine = Instantiate(garage.GetRandomCar(), enemyCar.transform).GetComponent<CarEngine>();
        
        enemyCarEngine.gameObject.SetActive(true);
        
        enemyCarEngine.StopEngine();
        playerCarEngine.StopEngine();
        
        playerCar.transform.localPosition = Vector3.zero;
        enemyCar.transform.localPosition = Vector3.zero;
        
        playerCarEngine.transform.localPosition = new Vector3(2.5f,0,0);
        enemyCarEngine.transform.localPosition = new Vector3(-2.5f,0,0);
    }

    public override void Initialize()
    {
        finish.SetActive(false);
        result.DOFade(0, 0.5f);
        playerCar.transform.localPosition = Vector3.zero;
        enemyCar.transform.localPosition = Vector3.zero;
        ongoing = true;
        aitStream.Play();
        enemyCarEngine.StartEngine();
        playerCarEngine.StartEngine();
    }

    private void Update()
    {
        if (!ongoing)
        {
            return;
        }

        transform.position -= Vector3.right * Time.deltaTime * 30;

        if (transform.position.x <= -150)
        {
            transform.position = pos - (Vector3.left * 150);
        }
    }

    public override void SelectCar(GameObject car)
    {
        if (playerCarEngine != null)
        {
            Destroy(playerCarEngine.gameObject);
        }
        playerCarEngine = Instantiate(car, playerCar.transform).GetComponent<CarEngine>();
    }

    public override void MoveCar(CarType type)
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

    public override void Finish()
    {
        ongoing = false;
        ScreenManager.instance.OpenScreen(ScreenTypes.Finish);
        transform.position = pos - (Vector3.left * 50);
        finish.SetActive(true);
        aitStream.Stop();

        Sequence sq = DOTween.Sequence();
        sq.Append(transform.DOMoveX(finish.transform.position.x, 2f).SetEase(Ease.Linear));
        sq.AppendCallback(() => result.DOFade(1, 0.5f));
        sq.Append(transform.DOMoveX(finish.transform.position.x - 20, 1f).SetEase(Ease.OutQuart));
        sq.AppendCallback(() =>
        {
            enemyCarEngine.StopEngine();
            playerCarEngine.StopEngine();
            playerCar.transform.localPosition = Vector3.zero;
            enemyCar.transform.localPosition = Vector3.zero;
            enemyCar.transform.localPosition = Vector3.zero;
        });
    }
}