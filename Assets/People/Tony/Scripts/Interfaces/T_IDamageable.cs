using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface T_IDamageable
{
    public void OnTakeDamage(int damage);
    public void OnTakeDamage(int damage, Vector2 knockback);
    public void OnTakeDamage(int damage, Vector2 knockback, ElementType type);
    public void OnDeath();


}
