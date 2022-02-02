using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "Acordo", menuName = "ScriptableObjects/Acordos")]
public class ContratosScript : ScriptableObject
{
    [Header("Acordo")]
    public string nameContrato;

    [Header("Player")]
    public float evadeChance;
    public float reducedDamage;

    [Header("World")]
    public bool fog; //activates a fog image on canvas
    public bool blurVision; //activates blur on post processing and it deactivates raw movement to player
}
