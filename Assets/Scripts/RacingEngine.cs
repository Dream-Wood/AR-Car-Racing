using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RacingEngine : MonoBehaviour
{
    [SerializeField] private Racing racing;

    [SerializeField] private TMP_Text numbers;
    [SerializeField] private GameObject testForm;
    
    [SerializeField] private TMP_Text questionTitle;
    [SerializeField] private List<TMP_Text> tbs;
    [SerializeField] private List<Button> bts;

    private QuestData data;

    private Vector3[] comb = new[]
    {
        new Vector3(0, 1, 2),
        new Vector3(0, 2, 1),
        new Vector3(2, 1, 0),
        new Vector3(2, 0, 1),
        new Vector3(1, 2, 0),
        new Vector3(1, 0, 2),
    };

    private int select = 0;

    public void Initialize(QuestData dq)
    {
        data = dq;
        select = 0;
        testForm.SetActive(false);
        BindingBtn();
        
        Sequence sq = DOTween.Sequence();
        sq.Append(numbers.DOText("3", 1f));
        sq.Append(numbers.DOText("2", 1f));
        sq.Append(numbers.DOText("1", 1f));
        sq.Append(numbers.DOText("GO", 0.01f));
        sq.AppendCallback(OnGoing);
    }

    void OnGoing()
    {
        racing.Initialize();
        numbers.text = "";
        testForm.SetActive(true);
    }

    void BindingBtn()
    {
        if (select >= data.Questions.Count)
        {
            racing.Finish();
            return;
        }
        
        foreach (var bt in bts)
        {
            bt.onClick.RemoveAllListeners();
        }

        int key = Random.Range(0, comb.Length);

        questionTitle.DOText(data.Questions[select].Text, .5f);


        for (int i = 0; i < bts.Count; i++)
        {
            if (i == 0)
            {
                tbs[(int)comb[key][i]].text = data.Questions[select].Answer;
                bts[(int)comb[key][i]].onClick.AddListener(Correct);
            }
            else
            {
                tbs[(int)comb[key][i]].text = data.Questions[select].BadAnswers[i - 1];
                bts[(int)comb[key][i]].onClick.AddListener(Error);
            }
        }
    }

    void Correct()
    {
        select++;
        racing.MoveCar(CarType.Player);
        BindingBtn();
    }

    void Error()
    {
        select++;
        BindingBtn();
        //Взрыв
    }
}