using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    private void Awake()
    {
        instance = this;
    }

    public Transform[] spawnPoints;

    
    void Start()
    {
        foreach(Transform spawn in spawnPoints)
        {
            spawn.gameObject.SetActive(false);
        }
    }

 
    void Update()
    {
        
    }

    public Transform GetSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
}
