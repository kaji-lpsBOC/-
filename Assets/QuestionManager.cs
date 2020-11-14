using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using TMPro;

public class QuestionManager: MonoBehaviour
{
    GameObject Question;
    Entity_Sheet1 es;

    // Start is called before the first frame update
    void Start()
    {
        es = Resources.Load("example") as Entity_Sheet1; //データの読み込み

        Question = GameObject.Find("Question");
        Question.GetComponent<TextMeshProUGUI>().text = es.sheets[0].list[0].question; 
    }

    public void NextQuestion(int _number,int _qnumber)
    {
        es = Resources.Load("example") as Entity_Sheet1;

        Question = GameObject.Find("Question");
        Question.GetComponent<TextMeshProUGUI>().text = es.sheets[_qnumber].list[_number].question;
    }
    
    public void NewQuetion(int _qnumber)
    {
        es = Resources.Load("example") as Entity_Sheet1; //データの読み込み

        Question = GameObject.Find("Question");
        Question.GetComponent<TextMeshProUGUI>().text = es.sheets[_qnumber].list[0].question;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
