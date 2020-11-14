using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class NowQuestionManager : MonoBehaviour
{
    GameObject NowQuestion;
    public Text Combo;
    Entity_Sheet1 es;

    // Start is called before the first frame update
    void Start()
    {
        es = Resources.Load("example") as Entity_Sheet1; //データの読み込み

        NowQuestion = GameObject.Find("NowQuestion");
        NowQuestion.GetComponent<TextMeshProUGUI>().text = es.sheets[0].list[0].q;
        Debug.Log("q1-1:" + es.sheets[0].list[0].q); 
    }

    public void NextQuestion(int _number,int _qnumber ,float _comb)
    {
        es = Resources.Load("example") as Entity_Sheet1;

        NowQuestion = GameObject.Find("NowQuestion");
        NowQuestion.GetComponent<TextMeshProUGUI>().text = es.sheets[_qnumber].list[_number].q;
        Combo.text = _comb.ToString() + "コンボ";
    }
    public void NewQuetion(int _qnumber)
    {
        es = Resources.Load("example") as Entity_Sheet1; //データの読み込み

        NowQuestion = GameObject.Find("NowQuestion");
        NowQuestion.GetComponent<TextMeshProUGUI>().text = es.sheets[_qnumber].list[0].q;
    }

}
