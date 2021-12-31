using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    private int spawnerID;
    private GameObject[] enemyObject;
    [SerializeField]
    private Transform spawnPoint;
    private void Start()
    {
        enemyObject = PrefabHolder.enemyObject;
    }
    public void SpawnEnemy(int enemyTypeIndex)
    {
        Instantiate(enemyObject[enemyTypeIndex],spawnPoint.position,Quaternion.identity);
    }
}
