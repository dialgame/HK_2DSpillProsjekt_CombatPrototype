using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage Resistances", menuName = "SO/Damage Resistances")]
public class ElementResistanceSO : ScriptableObject
{
    //Needs this to edit inside struct Resistance
    [System.Serializable]
    public struct Resistance 
    {
        public ElementTypes elementType;
        public float percentageToTake;
    }

    public List<Resistance> resistances = new List<Resistance>();

    public int CalculateDamageWithResistance(int damage, ElementTypes elementType)
    {
        //elementType looks through Resistance list to check for element related to the percentag dmg
        for (int i = 0; i < resistances.Count; i++)
        {
            if (resistances[i].elementType == elementType)
            {
                //converts potential float to int
                //returns dmg after resistance calculation
                return ((int)((damage * 100 ) / resistances[i].percentageToTake));
            }
            
            if (resistances[i].elementType != elementType)
            {
                //return ((damage * resistances[i].percentageToTake) / 100);
            }
        }
        return 0;

    }
}
