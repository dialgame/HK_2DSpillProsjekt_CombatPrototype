using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface T_IDamageable
{
    public void OnTakeDamage(int damage);
    public void OnTakeDamage(int damage, Vector2 knockback);
    public void OnDeath();

   // public void OnAttack(int damage, Vector2 knockback);

}
