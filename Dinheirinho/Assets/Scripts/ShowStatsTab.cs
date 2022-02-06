using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStatsTab : MonoBehaviour
{
    public GameObject loja;
    public GameObject stats;

    Animator anim => stats.GetComponent<Animator>();

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
                if (anim.GetBool("ativo"))
                {
                    anim.SetBool("ativo", false);
                }
                else
                {
                    anim.SetBool("ativo", true);
                }
            }

        }

    }
}
