using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    private static PlayerStat instance;
    private static int currency;
    private static int healthPoint;
    private static int rounds;
    [Header("optional stat")]
    public int startHealthPoint = 3;
    public int startCurrency = 300;
    [Header("Unity Setup")]
    public Text CurrenncyText;
    public Text HealthText;
    private void Awake()
    {   
        rounds = 0;
        healthPoint = startHealthPoint;
        currency = startCurrency;
        instance = this;
    }
    private void Update()
    {
        string outputConccurencyText = GetCurrency().ToString();
        CurrenncyText.text = outputConccurencyText;
        HealthText.text = GetHealthPoint().ToString() + " LIVES";
    }
    public static PlayerStat GetInstance()
    {
        return instance;

    }
    public int GetCurrency()
    {
        return currency;
    }
    public void DeCredit(int credit)
    {
        currency -= credit;
        if (currency < 0)
            Debug.Log("there are an error when purchasing turret");
    }
    public void AddCredit(int credit)
    {
        currency += credit;
    }
    public int GetHealthPoint()
    {
        return healthPoint;
    }
    public void SetHelthPoint(int _healthPoint)
    {
        healthPoint = _healthPoint;
    }
    public void MinusHealth(int health){
        healthPoint -= health;
    }
     public void SetRounds(int _rounds)
    {
        rounds = _rounds;
    }
    public int getRounds(){
        return rounds;
    }



}
