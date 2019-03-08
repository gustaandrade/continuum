using UnityEngine;

public class PlayerController : WrapObject
{
    public static PlayerController Instance; 

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
        Move();
        LookAtMouse();

        if (Input.GetMouseButton(0) && _cooldownCount > _gameVariables.PlayerShotCooldown)
            Shoot();
        _cooldownCount++;
    }

    private void Shoot()
    {
        _shotController.SpawnFromPool("Player", PlayerBulletOrigin.transform.position, PlayerBulletOrigin.transform.rotation);
        _cooldownCount = 0f;
    }

    private void Move()
    {
        var horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * _gameVariables.PlayerMovementSpeed;
        var verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * _gameVariables.PlayerMovementSpeed;
        var movement = new Vector2(horizontalInput, verticalInput);

        transform.Translate(movement, Space.World);
    }

    private void LookAtMouse()
    {
        var diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
    }
}
