using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AcordosShop : MonoBehaviour
{
    public AcordosScript[] acordosScriptableObjects;
    public PlayerStats playerStats;

    public GameObject acordo1;
    public GameObject acordo2;

    private int randomNum;
    private int randomNum2;
    private int maxNum;
    void Start()
    {
        maxNum = acordosScriptableObjects.Length;

        setRandom();
    }

    void Update()
    {
        //userString.Contains("stringToSearchFor")
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
        if(randomNum2 == randomNum)
        {
            setRandom();
        }
        else
        {
            StartShop();
        }

    }
    public void ClickButtonNum1()
    {
        playerStats.health += acordosScriptableObjects[randomNum].health;
        playerStats.maxHealth += acordosScriptableObjects[randomNum].maxHealth;
        playerStats.speed += acordosScriptableObjects[randomNum].speed;

        playerStats.dano += acordosScriptableObjects[randomNum].dano;
        playerStats.fireRate += acordosScriptableObjects[randomNum].fireRate;
        playerStats.range += acordosScriptableObjects[randomNum].range;

        playerStats.money += acordosScriptableObjects[randomNum].money;

        playerStats.UpdateAllStats();
    }
    public void ClickButtonNum2()
    {
        playerStats.health += acordosScriptableObjects[randomNum2].health;
        playerStats.maxHealth += acordosScriptableObjects[randomNum2].maxHealth;
        playerStats.speed += acordosScriptableObjects[randomNum2].speed;

        playerStats.dano += acordosScriptableObjects[randomNum2].dano;
        playerStats.fireRate += acordosScriptableObjects[randomNum2].fireRate;
        playerStats.range += acordosScriptableObjects[randomNum2].range;

        playerStats.money += acordosScriptableObjects[randomNum2].money;

        playerStats.UpdateAllStats();
    }
    public void FillObjects()
    {   
        playerStats.health += acordosScriptableObjects[randomNum].health;
        playerStats.maxHealth += acordosScriptableObjects[randomNum].maxHealth;
        playerStats.speed += acordosScriptableObjects[randomNum].speed;

        playerStats.dano += acordosScriptableObjects[randomNum].dano;
        playerStats.fireRate += acordosScriptableObjects[randomNum].fireRate;
        playerStats.range += acordosScriptableObjects[randomNum].range;

        playerStats.money += acordosScriptableObjects[randomNum].money;
    }

}
