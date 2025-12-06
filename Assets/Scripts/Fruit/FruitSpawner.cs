using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{

    [SerializeField] GameObject spawnPlatform;
    [SerializeField] List<GameObject> fruits = new List<GameObject>();

    private void Start()
    {

        StartCoroutine(SpawnObjects(fruits));
    }
    IEnumerator SpawnObjects(List<GameObject> objectsToSpawn)
    {
        while (true)
        {
            int randomNumber = Random.Range(0, objectsToSpawn.Count);
            Vector3 spawnPos = new Vector3(
                spawnPlatform.transform.position.x,
                spawnPlatform.transform.position.y,
                -4f
            );

            Instantiate(objectsToSpawn[randomNumber], spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(2f);
        }
    }
}

