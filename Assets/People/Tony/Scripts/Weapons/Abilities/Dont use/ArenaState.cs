using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaState : MonoBehaviour
{
    [SerializeField] T_EnemyBase enemyBase;

    private Collider2D targetCollider;

    //Advantage
    //Fire -> Wind -> Lightning -> Water -> Fire

    
    private enum ElementType {None, Fire, Lightning, Water, Wind, Melee}
    private ElementType element;

    //Vector3[] elementOrientation = new[]
    //{
    //    new Vector3 (0,0,0),
    //    new Vector3 (0,0,90),
    //    new Vector3 (0,0,180),
    //    new Vector3 (0,0,270)
    //};

  
    private void Update()
    {
        //ElementStatsVariation();
    }

    private void ElementStatsVariation()
    {
        //if(element == enemyBase.Type(0))
        //{
        //    if (targetCollider.CompareTag("Player"))
        //    {
        //        //effect on player
        //    }
        //    else if (targetCollider.CompareTag("Enemy"))
        //    {
        //        Debug.Log("Player Fire advantage");
        //    }
        //}
       
    //    else if(element == ElementType.Lightning)
    //    {
    //        if (targetCollider.CompareTag("Player"))
    //        {
    //            //effect on player
    //        }
    //        else if (targetCollider.CompareTag("Enemy"))
    //        {
    //            //effect on enemy
    //        }
    //    }
       
    //    else if (element == ElementType.Wind)
    //    {
    //        if (targetCollider.CompareTag("Player"))
    //        {
    //            //effect on player
    //        }
    //        else if (targetCollider.CompareTag("Enemy"))
    //        {
    //            //effect on enemy
    //        }
    //    }
       
    //    else if (element == ElementType.Water)
    //    {
    //        if (targetCollider.CompareTag("Player"))
    //        {
    //            //effect on player
    //        }
    //        else if (targetCollider.CompareTag("Enemy"))
    //        {
    //            //effect on enemy
    //        }
    //    }

    //    else if (element == ElementType.Melee)
    //    {
    //        if (targetCollider.CompareTag("Player"))
    //        {
    //            //effect on player
    //        }
    //        else if (targetCollider.CompareTag("Enemy"))
    //        {
    //            //effect on enemy
    //        }
    //    }
    }

}
