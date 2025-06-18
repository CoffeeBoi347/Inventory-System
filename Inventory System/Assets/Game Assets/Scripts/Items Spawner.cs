using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ItemsSpawner : MonoBehaviour
{
    public List<GameObject> _objsSpawn = new List<GameObject>();
    public float timeToSpawn;
    private bool canSpawn = false;

    [Header("Points To Spawn")]

    public Transform leftRange;
    public Transform rightRange;

    private void Start()
    {
        canSpawn = true;
    }

    private void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(SpawnObject(timeToSpawn));
        }
    }

    private IEnumerator SpawnObject(float time)
    {
        int index = Random.Range(0, _objsSpawn.Count);
        GameObject objToSpawn = _objsSpawn[index];
        float randomPos = Random.Range(leftRange.transform.position.x, rightRange.transform.position.y);
        Vector3 spawnPosition = new Vector3(randomPos, leftRange.transform.position.y, 0f);
        GameObject objectSpawn = Instantiate(objToSpawn, spawnPosition, Quaternion.identity);
        canSpawn = false;
        yield return new WaitForSeconds(time);
        canSpawn = true;
    }
}