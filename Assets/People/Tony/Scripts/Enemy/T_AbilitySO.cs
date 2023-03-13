using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "Ability/Create new Ability")]
public class T_AbilitySO : ScriptableObject
{
    [SerializeField] string abilityName;
    [SerializeField] string abilityDescription;
    [SerializeField] int abilityPower;
    [SerializeField] int abilitySpeed;
    [SerializeField] int abilityRange;
    [SerializeField] int manaCost;
    [SerializeField] ElementType abilityType;


    public string AbilityName => abilityName;
    public string AbilityDescription => abilityDescription;
    public int AbilityPower => abilityPower;
    public int AbilitySpeed => abilitySpeed;
    public int AbilityRange => abilityRange;
    public int ManaCost => manaCost;
    public ElementType AbilityType => abilityType;
   // public bool Death { get; set; }
    public float Critical { get; set; }
    public float TypeEffectiveness { get; set; }

}

