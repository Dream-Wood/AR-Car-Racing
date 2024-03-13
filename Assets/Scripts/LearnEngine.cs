using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LearnEngine : MonoBehaviour
{
    [SerializeField] private Button next;
    [SerializeField] private Button back;
    [SerializeField] private Button ready;
    [SerializeField] private Button ar;
    
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text text;
    
    private QuestData quest;

    private int select = 0;

    private void Start()
    {
        next.onClick.AddListener(() =>
        {
            select++;
            ButtonValid();
            UpdateText();
        });
        
        back.onClick.AddListener(() =>
        {
            select--;
            ButtonValid();
            UpdateText();
        });
        
        ar.onClick.AddListener(() =>
        {
            SceneManager.LoadSceneAsync(1);
        });
    }

    public void Initialize(QuestData qd)
    {
        quest = qd;
        select = 0;
        ButtonValid();
        UpdateText();
    }

    private void UpdateText()
    {
        title.DOText(quest.TextSegments[select].Title, .5f);
        text.DOText(quest.TextSegments[select].Text, .5f);
    }

    private void ButtonValid()
    {
        back.gameObject.SetActive(select != 0);

        if (quest.TextSegments.Count - 1 == select)
        {
            next.gameObject.SetActive(false);
            ready.gameObject.SetActive(true);
            ar.gameObject.SetActive(true);
        }
        else
        {
            next.gameObject.SetActive(true);
            ready.gameObject.SetActive(false);
            ar.gameObject.SetActive(false);
        }
    }
}
