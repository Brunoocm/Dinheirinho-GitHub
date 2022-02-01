using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Acordo", menuName = "ScriptableObjects/Acordos" )]
public class AcordosScript : ScriptableObject
{
    [Header("Acordo")]
    public string nameAcordo;

    [Header("Player")]
    public float health;
    public float maxHealth;
    public float speed;

    [Header("Fire")]
    public float dano;
    public float fireRate;
    public float range;

    [Header("Shop")]
    public float money;

}
