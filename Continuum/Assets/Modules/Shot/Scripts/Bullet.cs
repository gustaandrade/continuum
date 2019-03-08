using UnityEngine;

public class Bullet : MonoBehaviour, IBulletObject
{
    private Rigidbody2D _rigidbody;
    private GameVariables _gameVariables;
    private PlayerController _playerController;
    private EnemyController _enemyController;

    public void OnBulletSpawned()
    {
        if (_rigidbody == null) _rigidbody = GetComponentInChildren<Rigidbody2D>();
        if (_gameVariables == null) _gameVariables = GameVariables.Instance;
        if (_playerController == null) _playerController = PlayerController.Instance;
        if (_enemyController == null) _enemyController = EnemyController.Instance;

        if (gameObject.CompareTag("PlayerShot"))
            _rigidbody.AddForce(_playerController.gameObject.transform.up * _gameVariables.PlayerShotSpeed);
        else if (gameObject.CompareTag("EnemyShot"))
            _rigidbody.AddForce(_enemyController.gameObject.transform.up * _gameVariables.EnemyShotSpeed);
    }
}
