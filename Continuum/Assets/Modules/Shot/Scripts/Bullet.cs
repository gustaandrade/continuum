using UnityEngine;
using UnityEngine.SceneManagement;

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

        _rigidbody.velocity = Vector2.zero;
        _rigidbody.angularVelocity = 0f;

        if (gameObject.CompareTag("PlayerShot"))
            _rigidbody.AddForce(_playerController.PlayerBulletOrigin.transform.up * _gameVariables.PlayerShotSpeed);
        else if (gameObject.CompareTag("EnemyShot"))
            _rigidbody.AddForce(_enemyController.gameObject.transform.up * _gameVariables.EnemyShipShotSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (gameObject.CompareTag("PlayerShot") && collider.CompareTag("Enemy"))
        {
            Destroy(collider.transform.parent.gameObject);
            PlayerPrefsController.Instance.SetMaxScore(PlayerPrefsController.Instance.GetMaxScore() + 100);
        }
        else if (gameObject.CompareTag("EnemyShot") && collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
