using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AcordosShop : MonoBehaviour
{
    public AcordosScript[] acordosScriptableObjects;
    public PlayerStats playerStats;
    public TextMeshProUGUI[] textStats; 

    public GameObject acordo1;
    public GameObject acordo2;

    private int randomNum;
    private int randomNum2;
    private int maxNum;
    void Start()
    {
        maxNum = acordosScriptableObjects.Length;

        OpenShop();
 
    }

    void Update()
    {
        //userString.Contains("stringToSearchFor")
        textStats[5].text = "" + acordosScriptableObjects[randomNum].money;
        textStats[6].text = "" + acordosScriptableObjects[randomNum2].money;
    }
    void StartShop()
    {
        acordo1.GetComponentInChildren<TextMeshProUGUI>().text = acordosScriptableObjects[randomNum].nameAcordo;
        acordo2.GetComponentInChildren<TextMeshProUGUI>().text = acordosScriptableObjects[randomNum2].nameAcordo;
    }
    void setRandom()
    {
        randomNum = Random.Range(0, maxNum);
        randomNum2 = Random.Range(0, maxNum);
        //if(randomNum2 == randomNum)
        //{
        //    setRandom();
        //}
        //else
        //{
            StartShop();
        //}

    }

    public void OpenShop()
    {
        acordo1.SetActive(true);
        acordo2.SetActive(true);

        ExitButton(); //seta status
        setRandom();
    }
    public void ClickButtonNum1()
    {
        if (playerStats.money >= acordosScriptableObjects[randomNum].money * (-1))
        {
            playerStats.health += acordosScriptableObjects[randomNum].health;
            playerStats.maxHealth += acordosScriptableObjects[randomNum].maxHealth;
            playerStats.speed += acordosScriptableObjects[randomNum].speed;

            playerStats.dano += acordosScriptableObjects[randomNum].dano;
            playerStats.fireRate += acordosScriptableObjects[randomNum].fireRate;
            playerStats.range += acordosScriptableObjects[randomNum].range;
            playerStats.bulletSpeed += acordosScriptableObjects[randomNum].bulletSpeed;

            playerStats.money += acordosScriptableObjects[randomNum].money;

            acordo1.SetActive(false);

            playerStats.UpdateAllStats();
        }
    }
    public void ClickButtonNum2()
    {
        if (playerStats.money >= acordosScriptableObjects[randomNum2].money * (-1))
        {
            playerStats.health += acordosScriptableObjects[randomNum2].health;
            playerStats.maxHealth += acordosScriptableObjects[randomNum2].maxHealth;
            playerStats.speed += acordosScriptableObjects[randomNum2].speed;

            playerStats.dano += acordosScriptableObjects[randomNum2].dano;
            playerStats.fireRate += acordosScriptableObjects[randomNum2].fireRate;
            playerStats.range += acordosScriptableObjects[randomNum2].range;
            playerStats.bulletSpeed += acordosScriptableObjects[randomNum2].bulletSpeed;

            playerStats.money += acordosScriptableObjects[randomNum2].money;

            acordo2.SetActive(false);

            playerStats.UpdateAllStats();
        }
    }

    public void ShowStatsChange1()
    {
        if (acordosScriptableObjects[randomNum].speed != 0)
        {
            textStats[0].text = "" + acordosScriptableObjects[randomNum].speed;
        }
        if (acordosScriptableObjects[randomNum].dano != 0)
        {
            textStats[1].text = "" + acordosScriptableObjects[randomNum].dano;
        }
        if (acordosScriptableObjects[randomNum].fireRate != 0)
        {
            textStats[2].text = "" + acordosScriptableObjects[randomNum].fireRate;
        }
        if (acordosScriptableObjects[randomNum].range != 0)
        {
            textStats[3].text = "" + acordosScriptableObjects[randomNum].range;
        }
        if (acordosScriptableObjects[randomNum].bulletSpeed != 0)
        {
            textStats[4].text = "" + acordosScriptableObjects[randomNum].bulletSpeed;
        }
    }
    public void ShowStatsChange2()
    {
        if (acordosScriptableObjects[randomNum2].speed != 0)
        {
            textStats[0].text = "" + acordosScriptableObjects[randomNum2].speed;
        }
        if (acordosScriptableObjects[randomNum2].dano != 0)
        {
            textStats[1].text = "" + acordosScriptableObjects[randomNum2].dano;
        }
        if (acordosScriptableObjects[randomNum2].fireRate != 0)
        {
            textStats[2].text = "" + acordosScriptableObjects[randomNum2].fireRate;
        }
        if (acordosScriptableObjects[randomNum2].range != 0)
        {
            textStats[3].text = "" + acordosScriptableObjects[randomNum2].range;
        }
        if (acordosScriptableObjects[randomNum2].bulletSpeed != 0)
        {
            textStats[4].text = "" + acordosScriptableObjects[randomNum2].bulletSpeed;
        }
    }

    public void ExitButton()
    {
        textStats[0].text = "";
        textStats[1].text = "";
        textStats[2].text = "";
        textStats[3].text = "";
        textStats[4].text = "";
    }
}
