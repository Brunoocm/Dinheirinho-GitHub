using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeColor : MonoBehaviour
{
    public bool invert;
    TextMeshProUGUI textNum => GetComponent<TextMeshProUGUI>();
    private int num;
    void Start()
    {
    }

    void Update()
    {
        if(int.TryParse(textNum.text, out num))
        {
            num = int.Parse(textNum.text);

            if (num < 0)
            {
                if(!invert) textNum.color = Color.red;
                else textNum.color = Color.green;
            }
            else if (num > 0)
            {
                textNum.text += "+ ";
                if (!invert) textNum.color = Color.green;
                else textNum.color = Color.red;

            }
        }

    }


}
