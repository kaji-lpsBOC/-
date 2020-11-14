using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    public Text NowScore;
    public Text ResultScore;
    public Text Combo;
    public Text Speed;
    public Text LevelUp;
    public GameObject LevelPanel;

    public float base_point = 10000; //基本スコア(データベースからとってくるかも)
    public float sp_mag = 1;  //速さ
    public float combo_mag = 1; //連続正解
    public float[] score;
    public float[] speed;
    public float combo_max;
    public int exp;
    public int point;
    public int addpoint;

    public int level;
    public void Add_Score(int _qnum, float _speed, float _comb)
    {
        sp_mag -= (float)(_speed * 0.01);
        if (_comb > 1)
        {
            combo_mag += (float)(_comb * 0.1);
        }
        if(_comb > combo_max)
        {
            combo_max = _comb;
        }
        score[_qnum] = base_point * sp_mag * combo_mag;
        speed[_qnum] = _speed;
        
        NowScore.text = "+" + Math.Ceiling(score[_qnum]);
        
        Combo.text = _comb + "コンボ";
        Speed.text = "Time:" + _speed;
    }
    public void NowScore_Delete()
    {
        NowScore.text = "";
        Combo.text = "";
        Speed.text = "";
    }

    public void Show_Score()
    { 
        double SumScore = 0;
        for(int i = 1; i <= score.Length; i++)
        {
            score[i - 1] = (float)Math.Ceiling(score[i - 1]);
            speed[i - 1] = (float)Math.Ceiling(speed[i - 1]);
            ResultScore.GetComponent<Text>().text += $"({i}):Score : {score[i - 1]}    Speed : {speed[i - 1]}";
            ResultScore.GetComponent<Text>().text += "\r\n";
            SumScore += score[i - 1];  
        }

        ResultScore.GetComponent<Text>().text += "\r\n";
        ResultScore.text += "合計スコア:" + SumScore +  "\r\n\r\n" + "MaxCombo:" + combo_max + "コンボ"; //speed,combo ,cor_magを入れる（コンボが上がると技の演出が上がる）
        ResultScore.GetComponent<Text>().text += "\r\n";

        addpoint = (int)Math.Ceiling(SumScore / 100);
        ResultScore.GetComponent<Text>().text += "AddPoint: " + addpoint; //ポイント
        ResultScore.GetComponent<Text>().text += "\r\n";
        ResultScore.GetComponent<Text>().text += $"ポイント: {point} + {addpoint} ";

        ResultScore.GetComponent<Text>().text += "\r\n";
        exp = (int)Math.Ceiling(SumScore / 500);
        ResultScore.GetComponent<Text>().text += "Exp: " + exp; //レベル
        
        
        if (exp > 0)
        {
            LevelPanel.SetActive(true);
            LevelUp.text = "level 2 ==> 3"; 
        }
    }
    
   
}

