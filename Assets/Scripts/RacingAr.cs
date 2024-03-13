using System;
using DG.Tweening;
using PathCreation.Examples;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RacingAr : Racing
{
    [SerializeField] private PathFollower enemyCar;
    [SerializeField] private CarEngine enemyCarEngine;
    [SerializeField] private PathFollower playerCar;
    [SerializeField] private CarEngine playerCarEngine;

    [SerializeField] private Image result;
    [SerializeField] private TMP_Text text;

    [SerializeField] private float trackDistance;

    private bool run;

    public override void Initialize()
    {
        result.DOFade(0, 0.5f);

        playerCar.speed = 1;
        enemyCar.speed = 1;

        enemyCarEngine.StartEngine();
        playerCarEngine.StartEngine();

        run = true;
    }

    private void LateUpdate()
    {
        if (!run) return;

        if (playerCar.distanceTravelled >= trackDistance)
        {
            run = false;
            text.text = "Ты выйграл!";
            FinishRacing();
        }

        if (enemyCar.distanceTravelled >= trackDistance)
        {
            run = false;
            text.text = "Ты Проиграл :(";
            FinishRacing();
        }
    }

    public override void MoveCar(CarType type)
    {
        if (type == CarType.Player)
        {
            playerCar.speed++;
        }
        else
        {
            enemyCar.speed++;
        }
    }


    private void FinishRacing()
    {
        ScreenManager.instance.OpenScreen(2);
        result.DOFade(1, .5f);
        enemyCarEngine.StopEngine();
        playerCarEngine.StopEngine();
        playerCar.speed = 0;
        enemyCar.speed = 0;
    }

    public override void Finish()
    {
        ScreenManager.instance.OpenScreen(2);
    }

    public void GoMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}