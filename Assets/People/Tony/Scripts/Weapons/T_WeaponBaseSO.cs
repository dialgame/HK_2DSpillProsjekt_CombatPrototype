using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "SO/Weapon")]
public class T_WeaponBaseSO : ScriptableObject
{
    //[SerializeField] GameObject weaponBase; //able to choose/randomize which weapon when dropped?
    [SerializeField] int weaponDamage;
    [SerializeField] int weaponSpeed;
    [SerializeField] int knockbackForce;
    [SerializeField] bool isAvailable;
    //[SerializeField] int weaponDurability;
    //[SerializeField] float damage;

    public int WeaponDamage => weaponDamage;
    public int WeaponSpeed => weaponSpeed;
    public int KnockbackForce => knockbackForce;
    public bool IsAvailable => isAvailable;
    //public int WaponDurability => weaponDurability;


}
