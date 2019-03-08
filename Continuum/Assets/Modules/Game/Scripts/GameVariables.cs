using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariables : MonoBehaviour
{
    public static GameVariables Instance;

    [Header("Player")]
    public float PlayerMovementSpeed;
    public float PlayerShotSpeed;
    public float PlayerShotCooldown;
    public float PlayerScreenWrapOffset;

    [Space(5)]
    [Header("Enemy")]
    public float EnemyMovementSpeed;
    public float EnemyShotSpeed;

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
