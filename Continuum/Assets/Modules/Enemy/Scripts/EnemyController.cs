using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController Instance;

    public GameObject EnemyBulletOrigin;
    public AudioClip Clip;

    private float _cooldownCount;
    private float _positionX;
    private float _positionY;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        _positionX = Random.Range(-1f, 1f);
        _positionY = Random.Range(-1f, 1f);
    }

    private void FixedUpdate()
    {
        AutoMove();
        AutoRotate();

        if (_cooldownCount > GameVariables.Instance.EnemyShipShotCooldown && gameObject.CompareTag("EnemyShip"))
            Shoot();
        _cooldownCount++;
    }

    private void Shoot()
    {
        AudioController.Instance.PlayOneShotEnemySFX(Clip);
        ShotController.Instance.SpawnFromPool("Enemy", EnemyBulletOrigin.transform.position, EnemyBulletOrigin.transform.rotation);
        _cooldownCount = 0f;
    }

    private void AutoMove()
    {
        var movementSpeed = 0f;
        if (gameObject.CompareTag("EnemyShip")) movementSpeed = GameVariables.Instance.EnemyShipMovementSpeed;
        else if (gameObject.CompareTag("EnemyRock")) movementSpeed = GameVariables.Instance.EnemyRockMovementSpeed;

        var horizontalInput = _positionX * Time.deltaTime * movementSpeed;
        var verticalInput = _positionY * Time.deltaTime * movementSpeed;
        
        var movement = new Vector2(horizontalInput, verticalInput);

        transform.Translate(movement, Space.World);
    }

    private void AutoRotate()
    {
        var diff = Camera.main.ScreenToWorldPoint(PlayerController.Instance.gameObject.transform.position) - transform.position;
        diff.Normalize();

        var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
    }
}
