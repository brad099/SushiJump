using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    void Awake()
    {
        if (instance == null)
        {
             instance = this;
        }

        if (!PlayerPrefs.HasKey("Money"))
        {
          PlayerPrefs.SetInt("Money",0);
          PlayerPrefs.Save();
        }
    }


    public int UpdateMoney()
    {
        return PlayerPrefs.GetInt("Money");
    }

    public void SpendMoney(int Money)
    {
        int CurrentMoney = UpdateMoney() - Money;
        PlayerPrefs.SetInt("Money",CurrentMoney);
        UIController.instance.UpdateMoney();
    }

    public void AddMoney(int Money)
    {
       int CurrentMoney = UpdateMoney() + Money;
       PlayerPrefs.SetInt("Money",CurrentMoney);
       UIController.instance.UpdateMoney();
    }
}
