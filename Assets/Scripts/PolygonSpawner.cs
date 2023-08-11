using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int numberOfBullets = 10;
    public float radius = 2f;
    public int divCount = 8;
    public Vector3[] spawnPositions = new Vector3[5];

    void Start()
    {
        SpawnBullet();
    }

    void SpawnBullet()
    {
        float angleIncrement = 360f / numberOfBullets;

        for (int i = 0; i < numberOfBullets; i++)
        {
            float angle = i * angleIncrement;
            Vector3 spawnPosition = transform.position + Quaternion.Euler(0f, 180f, angle) * Vector3.up * radius;
            spawnPositions[i] = spawnPosition;
            Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
