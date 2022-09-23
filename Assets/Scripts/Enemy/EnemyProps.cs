using System.Collections;
using System.Collections.Generic;
using EMA.Scripts.PatternClasses;
using UnityEngine;

public class EnemyProps : MonoSingleton<EnemyProps>
{
   
    [SerializeField] private Transform currentPosition;
 

    public Transform CurrentPosition
    {
        get => currentPosition;
        set => currentPosition = value;
    }

   
}
