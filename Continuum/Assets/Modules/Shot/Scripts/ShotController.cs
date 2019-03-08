using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    public static ShotController Instance;
    public Dictionary<string, Queue<GameObject>> ShotDictionary;
    public List<Shot> Shots;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        ShotDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var shot in Shots)
        {
            var shotPool = new Queue<GameObject>();

            for (var i = 0; i < shot.Size; i++)
            {
                var newShot = Instantiate(shot.Prefab);
                newShot.SetActive(false);
                shotPool.Enqueue(newShot);
            }

            ShotDictionary.Add(shot.Type, shotPool);
        }
    }

    public GameObject SpawnFromPool(string type, Vector3 position, Quaternion rotation)
    {
        if (!ShotDictionary.ContainsKey(type)) return null;

        var nextShot = ShotDictionary[type].Dequeue();
        nextShot.SetActive(true);
        nextShot.transform.position = position;
        nextShot.transform.rotation = rotation;
        nextShot.GetComponent<IBulletObject>().OnBulletSpawned();

        ShotDictionary[type].Enqueue(nextShot);

        return nextShot;
    }
}

[System.Serializable]
public class Shot
{
    public string Type;
    public GameObject Prefab;
    public int Size;
}

public interface IBulletObject
{
    void OnBulletSpawned();
}