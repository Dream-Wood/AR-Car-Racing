using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GarageEngine : MonoBehaviour
{
    [SerializeField] private Garage garage;

    [SerializeField] private Button next;
    [SerializeField] private Button back;
    [SerializeField] private Button drive;
    [SerializeField] private Button ar;

    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text driveText;
    
    [SerializeField] private Racing dRacing;

    private int selectCar = 0;

    private int select;

    private void Start()
    {
        next.onClick.AddListener(() =>
        {
            select++;
            title.text = garage.SelectCar(select);
            ButtonValid();
        });

        back.onClick.AddListener(() =>
        {
            select--;
            title.text = garage.SelectCar(select);
            ButtonValid();
        });

        drive.onClick.AddListener(() =>
        { 
            var car = garage.GetCarById(select);
            dRacing.SelectCar(car);
            selectCar = select;
            ScreenManager.instance.GoBack();
        });
        

        ar.onClick.AddListener(() => { SceneManager.LoadSceneAsync(2); });
        
        ButtonValid();
    }


    private void ButtonValid()
    {
        back.gameObject.SetActive(select != 0);

        next.gameObject.SetActive(garage.GetCarsCount() - 1 != select);

        if (select == 0)
        {
            drive.interactable = true;
            driveText.text = "Выбрать";
            ar.interactable = false;
        }
        else
        {
            drive.interactable = true;
            driveText.text = "Выбрать";
            ar.interactable = false;
        }
    }

    private void OnDisable()
    {
        garage.SelectCar(selectCar);
    }
}