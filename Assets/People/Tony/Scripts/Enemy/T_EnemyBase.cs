using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Stats", menuName = "Enemy/Create new Enemy Stats")]
public class T_EnemyBase : ScriptableObject
{
    //Base stats for enemies
    [SerializeField] int moveSpeed;
    [SerializeField] int maxHealth;
    [SerializeField] int attackDamage;
    [SerializeField] float attackSpeed;
    [SerializeField] int defense;
    [SerializeField] int knockbackForce;
    [SerializeField] ElementType enemyType;
    [SerializeField] List<LearnableAbilities> learnableMoves;


    //properties
    public int MoveSpeed => moveSpeed;
    public int MaxHealth => maxHealth;
    public int AttackDamage => attackDamage;
    public float AttackSpeed => attackSpeed;
    public int Defense => defense;
    public int KnockbackForce => knockbackForce;

    public ElementType EnemyType => enemyType;

    public List<LearnableAbilities> LearnableAbilities => learnableMoves;

    
    
}
public class LearnableAbilities
{
    [SerializeField] T_AbilitySO abilityBase;
    public T_AbilitySO AbilityBase => abilityBase;
}
public enum ElementType { None, Fire, Lightning, Water, Wind, Melee }

public class TypeChart
{
    static float[][] chart = //static lets us use the chart directly from the class WITHOUT creating an OBJECT.
    {
            //Advantage
            //Fire -> Wind -> Lightning -> Water -> Fire
        //Remember to subtract one from the interger value of the ENUM because we have None as Index 0.
        //                          NOR  FIR   WIN  LIG   WAT   
        /*NOR*/        new float[] { 1f,  1f,   1f,  1f,   1f, },
        /*FIR*/        new float[] { 1f,  1f,   2f,  1f,  0.5f,},
        /*WIN*/        new float[] { 1f,  1f,  0.5f, 2f,   1f, },
        /*LIG*/        new float[] { 1f,  1f,   1f, 0.5f,  2f, },
        /*WAT*/        new float[] { 1f,  2f,   1f,  1f,  0.5f,},

    }; //a 2D array

    public static float TypeEffectiveness(ElementType attackType, ElementType defenseType)
    {
        if (attackType == ElementType.None || defenseType == ElementType.None)
        {
            return 1;
        }

        int row = (int)attackType - 1;
        int column = (int)defenseType - 1;

        return chart[row][column];
    }
}
