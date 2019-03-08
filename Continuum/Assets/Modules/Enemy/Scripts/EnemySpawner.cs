using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<int> EnemyWaves;
    public List<GameObject> Spawners;
    public GameObject EnemyShip;
    public GameObject EnemyRock;

    private int _currentWaveNumber = 0;

    private void OnEnable()
    {
        RandomizeEnemies();
    }

    private void RandomizeEnemies()
    {
        var currentWave = EnemyWaves.ElementAtOrDefault(_currentWaveNumber);

        for (var i = 0; i < currentWave; i++)
        {
            var enemy = Random.Range(0, 2) == 0 ? EnemyShip : EnemyRock;
            var spawner = Spawners.ElementAt(Random.Range(0, 4));

            if (spawner.CompareTag("Left") || spawner.CompareTag("Right"))
                enemy.transform.position = new Vector3(transform.position.x, Random.Range(-4f, 4f), transform.position.z);

            if (spawner.CompareTag("Up") || spawner.CompareTag("Down"))
                enemy.transform.position = new Vector3(Random.Range(-8f, 8f), transform.position.y, transform.position.z);

            Instantiate(enemy, spawner.transform);
        }
    }
}
