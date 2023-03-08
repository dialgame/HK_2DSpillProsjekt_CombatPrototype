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

    //properties
    public int MoveSpeed => moveSpeed;
    public int MaxHealth => maxHealth;
    public int AttackDamage => attackDamage;
    public float AttackSpeed => attackSpeed;
    public int Defense => defense;
    public int KnockbackForce => knockbackForce;

 
    
}
