using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.IO;

public class BattleMainSystem : MonoBehaviour
{
    public ScoreManager scoreManager;
    public Unit player;
    public Unit enemy;

    public QuestionManager Question;
    public NowQuestionManager NowQuestion;

    public SoundManager SoundManager;

    public string answer;
    public int number = 0; //問題経過管理
    public int QuestionNumber = 0; //問題番号管理 staticだった

    public GameObject GameoverPanel;
    public GameObject ResultPanel;
    public GameObject Output;

    public Text R_Time;
    public Text Qnum;

    public Image Ans_maru;
    public Image Ans_bastu;

    float RTime = 100;
    public float countTime = 0;
    public float cor_num = 0;

    float second = 0f;
    float showtime = 0f;
    bool IsPlayerTurn;
    bool IsGameOver;
    bool IsMaruBastu;
    Entity_Sheet1 es;

    void Start()
    {
        SoundManager.sound_bgm();

        IsPlayerTurn = true;
        IsMaruBastu = false;
        IsGameOver = false;
        GameoverPanel.SetActive(false);
        ResultPanel.SetActive(false);

        es = Resources.Load("example") as Entity_Sheet1;


        Debug.Log("player-hp" + player.hp);
        Debug.Log("player" + enemy.hp);
    }
    void ViewGameover()
    {
        GameoverPanel.SetActive(true); 
    }
       

    void Update()
    {
        Qnum.text = "Battle: " + (QuestionNumber + 1) + "/3";
        RTime -= Time.deltaTime; 
        R_Time.GetComponent<Text>().text = "Time : " + RTime.ToString("F2");

        countTime += Time.deltaTime; 

        if (IsGameOver)
        {
            ViewGameover();
            return;
        }
        if (player.hp <= 0)
        {
            IsGameOver = true;
        }
        if (!IsPlayerTurn)
        {
            second += Time.deltaTime;
            if (second >= 1f)
            {
                second = 0;
                player.OnDamage(enemy.at);
                
                scoreManager.NowScore_Delete();
                
                IsPlayerTurn = true;
            }
        }
        if (IsMaruBastu)
        {
            showtime += Time.deltaTime;
            if (showtime >= 1f)
            {   
                //ダメージ音
                showtime = 0;
                Ans_maru.enabled = false; //○、✖を隠す
                Ans_bastu.enabled = false;

                IsMaruBastu = false;
            }
        }
    }

    public void PushAttackButton() { 

        Output = GameObject.Find("Output");
        answer = Output.GetComponent<TextMeshProUGUI>().text;
   
        if (answer == es.sheets[QuestionNumber].list[number].qans) //正解時
        {
            enemy.OnDamage(player.at);
            cor_num += 1;

            SoundManager.sound_maru();
            Ans_maru.enabled = true;//○の表示
            IsMaruBastu = true;　

            Output.GetComponent<TextMeshProUGUI>().text = "";

            if (number < es.sheets[QuestionNumber].list[number].qans.Length) //途中式移動
            {
                number++;
                Question.NextQuestion(number,QuestionNumber);
                NowQuestion.NextQuestion(number,QuestionNumber,cor_num);
            }
            else
            {
                //スコア可算
                scoreManager.Add_Score(QuestionNumber, countTime, cor_num);
                countTime = 0;

                number = 0;
                QuestionNumber++;
                if (QuestionNumber == 3 /*後で変更*/ ) //ステージ終了時
                {
                    ResultPanel.SetActive(true);       
                    scoreManager.Show_Score();
                    SoundManager.sound_clear();
                }
                else
                { //次の問題に移行
                    enemy.HpReset(QuestionNumber);

                    Question.NewQuetion(QuestionNumber);
                    NowQuestion.NewQuetion(QuestionNumber);
                }
            }
            
        }
        else
        {
            SoundManager.sound_batsu();
            Ans_bastu.enabled = true; //✖の表示
            IsMaruBastu = true;
            Output.GetComponent<TextMeshProUGUI>().text = "";
            IsPlayerTurn = false;
            cor_num = 0; //コンボ0に
        }
    }
}
