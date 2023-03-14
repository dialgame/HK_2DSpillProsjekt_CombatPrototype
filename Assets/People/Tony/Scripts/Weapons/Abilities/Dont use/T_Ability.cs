using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Ability
{
    public T_AbilitySO AbilityBase { get; set; }
    public int ManaCost { get; set; }
    public T_Ability(T_AbilitySO abilityBase)
    {
        AbilityBase = abilityBase;
        ManaCost = abilityBase.ManaCost;
    }
}
