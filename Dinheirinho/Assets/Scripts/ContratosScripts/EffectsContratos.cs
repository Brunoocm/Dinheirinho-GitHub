using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EffectsContratos : MonoBehaviour
{
    public PlayerStats playerStats;

    public bool[] boolean;

    public SkillLuz acabouLuz;               // 0
    public SkillDrunk skillDrunk;            // 1
    public SkillPoision skillPoision;        // 2
    public SkillDanoArea skillDanoArea;      // 3
    public SkillHoraExtra skillHoraExtra;    // 4

    void Start()
    {
        skillHoraExtra.playerHealth.canHeal = true;
        skillHoraExtra.playerHealth.extraLife = false;
        skillDanoArea.playerAim.dinheiroBullet.GetComponent<BulletDamage>().isArea = false;
        skillPoision.playerAim.dinheiroBullet.GetComponent<BulletDamage>().isPoision = false;
    }

    void Update()
    {
        AcabouLuz(); //FEITO
        HappyHour(); //FEITO
        Virose(); //FEITO
        RasgandoDinheiro(); //FEITO
        HoraExtra(); //FEITO
    }

    public void AcabouLuz()
    {
        if (boolean[0])
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
        if (boolean[1])
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
        if(boolean[2] && !skillPoision.oneTime)
        {
            skillPoision.playerAim.dinheiroBullet.GetComponent<BulletDamage>().isPoision = true;
            playerStats.maxHealth = playerStats.maxHealth / 2;
            skillPoision.oneTime = true;

        }
        else if(!boolean[2])
        {
            skillPoision.playerAim.dinheiroBullet.GetComponent<BulletDamage>().isPoision = false;
            skillPoision.oneTime = false;
        }
    } 
    public void RasgandoDinheiro()
    {
        if (boolean[3] && !skillDanoArea.oneTime)
        {
            skillDanoArea.playerAim.dinheiroBullet.GetComponent<BulletDamage>().isArea = true;
            skillDanoArea.playerAim.reduceMoney = 2;
            skillDanoArea.oneTime = true;

        }
        else if(!boolean[3])
        {
            skillDanoArea.playerAim.dinheiroBullet.GetComponent<BulletDamage>().isArea = false;
            skillDanoArea.oneTime = false;
        }
    } 
    public void HoraExtra()
    {
        if (boolean[4])
        {
            skillHoraExtra.playerHealth.canHeal = false;
            skillHoraExtra.playerHealth.extraLife = true;
        }
        else
        {
            skillHoraExtra.playerHealth.canHeal = true;
            skillHoraExtra.playerHealth.extraLife = false;
        }
    }

    [System.Serializable]
    public class SkillLuz
    {
        public GameObject fog;
        public Sprite sprite;
    }

    [System.Serializable]
    public class SkillDrunk
    {
        public float maxSpeed;
        public float MinSpeed;
        public TextMeshProUGUI texto;
        public float num;
        public Sprite sprite;
    }
    
    [System.Serializable]
    public class SkillPoision
    {
        public GameObject normalBullet;
        public PlayerAim playerAim;
        public bool oneTime;
        public Sprite sprite;
    }
    
    [System.Serializable]
    public class SkillDanoArea
    {
        public GameObject normalBullet;
        public PlayerAim playerAim;
        public bool oneTime;
        public Sprite sprite;
    }

    [System.Serializable]
    public class SkillHoraExtra
    {
        public PlayerHealth playerHealth;
        public Sprite sprite;
    }
}
