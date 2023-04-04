using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] GameObject diamond;
    float spawnDelay = 0.2f;
    float spawnTimer;
    void Start()
    {
        spawnTimer = spawnDelay;
        for(int i = 0; i < 20; i++)
        {
            SpawnPlatform();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer < 0)
        {
            spawnTimer = spawnDelay;
            SpawnPlatform();
        }
        else spawnTimer -= Time.deltaTime;

    }

    void SpawnPlatform()
    {
        bool xAndNotZ = Random.Range(0, 2) == 1;
        float newXPos = transform.position.x;
        float newZPos = transform.position.z;
        if (xAndNotZ) newXPos += 2;
        else newZPos += 2;
        transform.position = new Vector3(newXPos, transform.position.y, newZPos);
        Instantiate(platform, transform.position, Quaternion.identity);
        SpawnDiamond();
    }

    void SpawnDiamond()
    {
        bool diamondWillBeSpawned = Random.Range(0, 2) == 1;
        if (diamondWillBeSpawned)
        {
            float diamondXPos = transform.position.x + Random.Range(-0.5f, 0.5f);
            float diamondZPos = transform.position.z + Random.Range(-0.5f, 0.5f);
            Vector3 diamondPos = new Vector3(diamondXPos, 0.8f, diamondZPos);
            Quaternion diamondRotation = Quaternion.Euler(-89.98f, 0, 0);
            Instantiate(diamond, diamondPos, diamondRotation);
        }
    }
}
