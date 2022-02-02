using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeColor : MonoBehaviour
{
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
                textNum.color = Color.red;
            }
            else if (num > 0)
            {
                textNum.text += "+ ";
                textNum.color = Color.green;

            }
        }

    }


}
