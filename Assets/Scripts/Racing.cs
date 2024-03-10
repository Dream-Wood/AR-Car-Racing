using System;
using DG.Tweening;
using UnityEngine;

public class Racing : MonoBehaviour
{
    [SerializeField] private GameObject enemyCar;
    [SerializeField] private GameObject playerCar;

    private Vector3 pos;
    private bool ongoing;

    public void Initialize()
    {
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
    }
}

public enum CarType
{
    Player = 0,
    Enemy = 1,
}