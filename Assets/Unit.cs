using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class Unit : MonoBehaviour
{
    public Slider HPSlider;
    public int hp;
    public int hpMax;
    public int at;

    Entity_Sheet1 es;

    void Start()
    {
        es = Resources.Load("example") as Entity_Sheet1;
        
        hpMax = es.sheets[0].list[0].hp;

        hp = hpMax;
        HPSlider.maxValue = hpMax;
        HPSlider.value = hpMax;
        at = 10; 
    }

    public void HpReset(int _qnum)
    {
        hpMax = es.sheets[_qnum].list[0].hp;

        hp = hpMax;
        HPSlider.maxValue = hpMax;
        HPSlider.value = hpMax;
        at = 10;
    }
    public void OnDamage(int _damage) //voidは戻り値無しの意味
    {
        hp -= _damage;
        if (hp <= 0)
        {
            hp = 0;
        }
        HPSlider.value = hp;
        Debug.Log(hp);
    }

}
