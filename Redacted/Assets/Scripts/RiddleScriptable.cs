using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class RiddleScriptable : ScriptableObject
{
    [SerializeField]
    private string AskedQuestion;
    [SerializeField]
    private string CorrectAnswer;
    [SerializeField]
    private char[] CurrentClue;    
    
    public char[] Clue
    {
        get { return CurrentClue; }
    }

    public string Question
    {
        get { return AskedQuestion; }
    }

    public void SetUp()
    {
        CurrentClue = new char[CorrectAnswer.Length];            
        for (int i = 0; i < CorrectAnswer.Length; i++)
        {
            if (CorrectAnswer[i] != ' ' && (int)CorrectAnswer[i] != 39)
                CurrentClue[i] = '_';
            else
                CurrentClue[i] = CorrectAnswer[i];
        }        
    }

    public bool CheckAnswer(string input)
    {
        return input == CorrectAnswer;
    }

    public char[] GenerateClue()
    {
        if (CheckAnswer(CurrentClue.ToString()))
            return CurrentClue;
        int value = Random.Range(0, CorrectAnswer.Length);
        if (CurrentClue[value] == CorrectAnswer[value])
            GenerateClue();
        CurrentClue[value] = CorrectAnswer[value];
        return CurrentClue;
    }
}
