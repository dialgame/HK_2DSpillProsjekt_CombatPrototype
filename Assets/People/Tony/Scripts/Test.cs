using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    //1, delegate funker som enum men brukt annerledes. Strukturen på hvordan det skjer er litt annerledes enn enum.
    public delegate void OnEnemyDeathDelegate(Test enemy);
    //2, static for instance for å skrive til, event for Access! Begge to er viktig.
    public static event OnEnemyDeathDelegate onEnemyDeath;

    public string someString;



    ////Subscribe, 5
    //private void OnEnable()
    //{
    //    onEnemyDeath += Foo;
    //    onEnemyDeath += Boo;
    //}

    ////Unsubscribe, 5
    //private void OnDisable()
    //{
    //    onEnemyDeath -= Foo;
    //    onEnemyDeath -= Boo;
    //}


    //4
    //void Foo()
    //{
    //    Debug.Log("I am me");
    //}


    //void Boo()
    //{
    //    Debug.Log("You are you");
    //}
    private void OnDeath()
    {
        Destroy(gameObject);
        //3, ? = (if(onEnemyDeath != null))
        onEnemyDeath?.Invoke(this);
            
    }

    //Delegates weakness: access everywhere. Add "Event", failsafe access. private to invoke the script itself, no public access for invoke and "=" for changes.
}
