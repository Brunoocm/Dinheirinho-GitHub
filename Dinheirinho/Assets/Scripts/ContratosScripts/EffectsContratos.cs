using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EffectsContratos : MonoBehaviour
{
    public PlayerStats playerStats;
    public bool acabouLuzBool;
    public bool happyHourBool;
    public bool viroseBool;
    public bool rasgandoDinheiroBool;
    public bool horaExtraBool;

    public SkillLuz acabouLuz;
    public SkillDrunk skillDrunk;
    public SkillPoision skillPoision;
    public SkillDanoArea skillDanoArea;
    void Start()
    {
        skillDanoArea.playerAim.dinheiroBullet.GetComponent<BulletDamage>().isArea = false;
        skillPoision.playerAim.dinheiroBullet.GetComponent<BulletDamage>().isPoision = false;
    }

    void Update()
    {
        AcabouLuz();//FEITO
        HappyHour();//FEITO
        Virose(); //FEITO
        RasgandoDinheiro(); //FEITO
        HoraExtra();
    }

    public void AcabouLuz()
    {
        if (acabouLuzBool)
        {
            acabouLuz.fog.SetActive(true);
            acabouLuz.fog.transform.position = playerStats.transform.position;
            playerStats.evadeChance = 30;
        }
        else
        {
            playerStats.evadeChance = 0;
            acabouLuz.fog.SetActive(false);
        }
    }
    public void HappyHour()
    {
        if (happyHourBool)
        {
            playerStats.reducedDamage = 30;

            skillDrunk.num += Random.Range(skillDrunk.MinSpeed, skillDrunk.maxSpeed) * 0.1f;
            skillDrunk.num -= Random.Range(skillDrunk.MinSpeed, skillDrunk.maxSpeed) * 0.1f;

            if (skillDrunk.num < skillDrunk.MinSpeed)
            {
                skillDrunk.num = skillDrunk.MinSpeed;
            }
            else if(skillDrunk.num > skillDrunk.maxSpeed)
            {
                skillDrunk.num = skillDrunk.maxSpeed;

            }

            playerStats.speed = Mathf.Round(skillDrunk.num);

             //= skillDrunk.num;

        }
        else
        {
            playerStats.reducedDamage = 0;

        }
    } 
    public void Virose()
    {
        if(viroseBool && !skillPoision.oneTime)
        {
            skillPoision.playerAim.dinheiroBullet.GetComponent<BulletDamage>().isPoision = true;
            playerStats.maxHealth = playerStats.maxHealth / 2;
            skillPoision.oneTime = true;

        }
        else if(!viroseBool)
        {
            skillPoision.playerAim.dinheiroBullet.GetComponent<BulletDamage>().isPoision = false;
            skillPoision.oneTime = false;
        }
    } 
    public void RasgandoDinheiro()
    {
        if (rasgandoDinheiroBool && !skillDanoArea.oneTime)
        {
            skillDanoArea.playerAim.dinheiroBullet.GetComponent<BulletDamage>().isArea = true;
            skillDanoArea.playerAim.reduceMoney = 2;
            skillDanoArea.oneTime = true;

        }
        else if(!rasgandoDinheiroBool)
        {
            skillDanoArea.playerAim.dinheiroBullet.GetComponent<BulletDamage>().isArea = false;
            skillDanoArea.oneTime = false;
        }
    } 
    public void HoraExtra()
    {

    }

    [System.Serializable]
    public class SkillLuz
    {
        public GameObject fog;

    }

    [System.Serializable]
    public class SkillDrunk
    {
        public float maxSpeed;
        public float MinSpeed;
        public TextMeshProUGUI texto;
        public float num;
    }
    
    [System.Serializable]
    public class SkillPoision
    {
        public GameObject normalBullet;
        public PlayerAim playerAim;
        public bool oneTime;
    }
    
    [System.Serializable]
    public class SkillDanoArea
    {
        public GameObject normalBullet;
        public PlayerAim playerAim;
        public bool oneTime;

    }
}
