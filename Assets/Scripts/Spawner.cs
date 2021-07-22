using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] pointsOfSpawn;
    [SerializeField] private GameObject spawnedGO;
    [SerializeField] private float timeBetweenSpawn;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawn);
            int rnd = Random.Range(0, pointsOfSpawn.Length);
            Instantiate(spawnedGO, pointsOfSpawn[rnd].position, Quaternion.identity);
        }
    }


}
