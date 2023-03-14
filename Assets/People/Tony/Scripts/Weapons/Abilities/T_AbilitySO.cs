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

    public string AbilityName => abilityName;
    public string AbilityDescription => abilityDescription;
    public int AbilityPower => abilityPower;
    public int AbilitySpeed => abilitySpeed;
    public int AbilityRange => abilityRange;
    public int ManaCost => manaCost;


}

