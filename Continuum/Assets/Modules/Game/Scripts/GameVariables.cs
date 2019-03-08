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

    [Header("Enemy")]
    public float EnemyShipMovementSpeed;
    public float EnemyShipShotSpeed;
    public float EnemyShipShotCooldown;
    public float EnemyRockMovementSpeed;

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}