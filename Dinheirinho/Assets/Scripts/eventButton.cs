using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class eventButton : MonoBehaviour, IPointerEnterHandler, ISelectHandler, IPointerExitHandler
{
    public bool isOne;
    public AcordosShop acordosShop;
    void Start()
    {

    }

    void Update()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //do your stuff when highlighted
        if(isOne) acordosShop.ShowStatsChange1();
        else acordosShop.ShowStatsChange2();

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        acordosShop.ExitButton();
     
    }
    public void OnSelect(BaseEventData eventData)
    {
        acordosShop.ExitButton();

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
