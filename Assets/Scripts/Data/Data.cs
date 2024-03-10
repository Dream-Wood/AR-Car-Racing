using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

[CreateAssetMenu(fileName = "New QuestData", menuName = "Data/Quest")]
public class QuestData : ScriptableObject
{
    public string Title;
    public List<LearnTextSegment> TextSegments;
    public List<Question> Questions;

    public int CoinReward;
    public int StarsReward;
}
