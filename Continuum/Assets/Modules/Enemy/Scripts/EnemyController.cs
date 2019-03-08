using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController Instance;

    public GameObject PlayerBulletOrigin;
    private GameVariables _gameVariables;
    private ShotController _shotController;

    private float _cooldownCount;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        _gameVariables = GameVariables.Instance;
        _shotController = ShotController.Instance;
    }

    private void FixedUpdate()
    {
        //AutoMove();
        //Rotate();
        if (_cooldownCount > _gameVariables.PlayerShotCooldown)
            Shoot();

        _cooldownCount++;
    }

    private void Shoot()
    {
        _shotController.SpawnFromPool("Player", PlayerBulletOrigin.transform.position, PlayerBulletOrigin.transform.rotation);
        _cooldownCount = 0f;
    }
}
