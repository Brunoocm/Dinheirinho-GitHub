using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventButton : MonoBehaviour
{
    public AcordosShop acordosShop;
    void Start()
    {

    }

    void Update()
    {

    }

    public void ShowStatsChange1()
    {
        acordosShop.ShowStatsChange1();
    }
    public void ShowStatsChange2()
    {
        acordosShop.ShowStatsChange2();

    }
    public void ExitButton()
    {
        acordosShop.ExitButton();
    }
}
