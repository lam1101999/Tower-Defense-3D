using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    private static PlayerStat instance;
    [Header("optional stat")]
    public int healthPoint = 3;
    public int startCurrency = 300;
    [Header("Unity Setup")]
    public Text CurrenncyText;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        string outputConccurencyText = GetCurrency().ToString();
        CurrenncyText.text = outputConccurencyText;
    }
    public static PlayerStat GetInstance()
    {
        if (instance == null)
        {
            instance = new PlayerStat();
        }
        return instance;

    }
    public int GetCurrency()
    {
        return startCurrency;
    }
    public void DeCredit(int credit)
    {
        startCurrency -= credit;
        if (startCurrency < 0)
            Debug.Log("there are an error when purchasing turret");
    }


}
