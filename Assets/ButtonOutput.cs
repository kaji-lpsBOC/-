using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonOutput : MonoBehaviour
{
    public GameObject btn;
    public string input_num;
    public GameObject Output;

    public void OnClick()
    {
        input_num = GetComponentInChildren<TextMeshProUGUI>().text;
        Debug.Log(input_num);
        btn = GameObject.Find("Output");
        btn.GetComponent<TextMeshProUGUI>().text += input_num;

    }

    public void OnClick_Left()
    {
        Output = GameObject.Find("Output");
        Output.GetComponent<TextMeshProUGUI>().text = "";
    }

    public void OnClick_Right()
    {
        Output = GameObject.Find("Output");
        Output.GetComponent<TextMeshProUGUI>().text += " && ";　//押された回数を渡して、番号を表示番号ごとに改行
    }
}
