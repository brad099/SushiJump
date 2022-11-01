using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{
    public static UIController instance;
    [SerializeField]TMP_Text MoneyText;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        UpdateMoney();
    }

    void Update()
    {
        
    }


    public void SpeedUP()
    {
            ClickerController.instance.SpeedUP();
    }
    public void PriceUP()
    {
            ClickerController.instance.PriceUP();
    }
    public void AddSeat()
    {
             ClickerController.instance.AddSeat();
    }

    public void UpdateMoney()
    {
        MoneyText.text = MoneyManager.instance.UpdateMoney().ToString();
    }


}
