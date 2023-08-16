using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int numberOfBullets = 10;
    public float radius = 2f;
    public int divCount = 8;
    public Vector3[] spawnPositions = new Vector3[5];
    public float createTime = 2f;
    float currentTime = 0;


    void Start()
    {
        SpawnBulletStar();
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        if( currentTime > createTime )
        {
            SpawnBulletStar();
            currentTime = 0;
        }
    }
    void SpawnBulletStar()
    {
        float angleIncrement = 360f / numberOfBullets;

        for (int i = 0; i < numberOfBullets; i++)
        {
            float angle = i * angleIncrement;
            Vector3 spawnPosition = transform.position + Quaternion.Euler(0f, 180f, angle) * Vector3.up * radius;
            spawnPositions[i] = spawnPosition;
            Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        }
        for(int i=0; i<spawnPositions.Length; i++)
        {
            Vector3 starPos1 = spawnPositions[i];
            Vector3 starPos2 = i+2 < 5 ? spawnPositions[i+2] : spawnPositions[i-3];

            for(int j=0; j < divCount; j++)
            {
                if (i != 0 && j == 3) j++;
                if (j == 4)
                {
                    j++;
                }
                if (i == 4 && j == 5) j++;

                float t = (float)j / divCount;
                Vector3 spawnPosition = Vector3.Lerp(starPos1, starPos2, t);
                Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

            }
        }
    }
}
