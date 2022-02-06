using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStatsTab : MonoBehaviour
{
    public GameObject loja;
    public GameObject stats;
    void Start()
    {
        
    }

    void Update()
    {
        if (loja.activeSelf == true)
        {
            stats.SetActive(true);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (stats.activeSelf)
                {
                    stats.SetActive(false); 

                }
                else if (!stats.activeSelf)
                {
                    stats.SetActive(true);

                }
            }

        }

    }
}
