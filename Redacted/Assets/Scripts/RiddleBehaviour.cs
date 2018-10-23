using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiddleBehaviour : MonoBehaviour
{
    public RiddleScriptable RiddleRef;
    public SwingHazardBehaviour HazardRef;
    public Text ClueDisplay;
    public Text RiddleDisplay;
    public string UserGuess;    
    public float ClueDelay;
    public string CurrentClue;
    public int NumClues = 0;
    
    void Awake()
    {
        RiddleRef.SetUp();
        char[] data = RiddleRef.Clue;
        foreach (var c in data)
        {
            CurrentClue += c;
            ClueDisplay.text += c + " ";
        }
        RiddleDisplay.text = RiddleRef.Question;                
    }

    float clueTimer = 0;
    public float TotalTime = 0;
	// Update is called once per frame
	void Update ()
    {
        TotalTime += Time.deltaTime;
        clueTimer += Time.deltaTime;
        if (TotalTime >= CurrentClue.Length * ClueDelay &&
            !RiddleRef.CheckAnswer(UserGuess))
        {
            StopCoroutine("ClueAnimation");
            ClueDisplay.color = Color.yellow;
            HazardRef.Trigger();
            return;
        }
        if (clueTimer >= ClueDelay)
        {
            if (NumClues < CurrentClue.Length / 2)
            {
                StartCoroutine("ClueAnimation");
                NumClues++;
            }
            clueTimer = 0;
        }

	}

    IEnumerator ClueAnimation()
    {        
        while(true)
        {
            ClueDisplay.color = Color.red;            
            ClueDisplay.text = "";
            CurrentClue = "";
            char[] data = RiddleRef.GenerateClue();
            foreach (var c in data)
            {
                CurrentClue += c;
                ClueDisplay.text += c + " ";
            }
            yield return new WaitForSeconds(0.5f);
            ClueDisplay.color = Color.black;
            break;
        }
    }

    public void SubmitAnswer(InputField inputData)
    {
        UserGuess = inputData.text;
        if (RiddleRef.CheckAnswer(UserGuess))
            ClueDisplay.color = Color.green;
        else
            TotalTime = 9999;
    }
}
