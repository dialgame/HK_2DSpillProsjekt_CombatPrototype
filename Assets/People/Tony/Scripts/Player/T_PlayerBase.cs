using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Player Stats", menuName = "Player/Create new Player Stats")]
public class T_PlayerBase : ScriptableObject
{

    [SerializeField] int maxHealth;
   // [SerializeField] int currentHealth;
    [SerializeField] int maxMana;
    //[SerializeField] int currentMana;

    [SerializeField] int moveSpeed = 5;//can be buffed with ability?
    [SerializeField] int attackDamage = 5;//dmg multiply with weapondmg?
    [SerializeField] float attackSpeed = 5; //atkspeed multiply with weaponspeed?
    [SerializeField] int defense = 5; //
                     
    [SerializeField] float magnet = 5; //magnet for pickup drops
    //[SerializeField] int recovery;//healing over time without dmg?

    //properties
    public int MaxHealth => maxHealth;
   // public int CurrentHealth => currentHealth;
    public int MaxMana => maxMana;
    //public int CurrentMana => currentMana;
    public int MoveSpeed => moveSpeed;
    public int AttackDamage => attackDamage;
    public float AttackSpeed => attackSpeed;
    public int Defense => defense;
    public float Magnet => magnet;
    //public int Recovery => recovery;


}
