using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLinked : MonoBehaviour
{
    private void OnEnable()
    {
        Test.onEnemyDeath += OnEnemyDeath;
    }

    private void OnDisable()
    {
        Test.onEnemyDeath -= OnEnemyDeath;
    }

    void OnEnemyDeath(Test enemy)
    {
        //response, f.eks. celebration
        //debug.log($"{enemy} has died");
        //enemy.someString ("haha, you died");
    }
}
