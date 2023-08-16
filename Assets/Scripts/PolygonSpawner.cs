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
    public float createTime;
    float currentTime;

    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        SpawnBullet();
    }

    void SpawnBullet()
    {
        currentTime += Time.deltaTime;
        if(currentTime > createTime)
        {
            float angleIncrement = 360f / numberOfBullets;

            for (int i = 0; i < numberOfBullets; i++)
            {
                float angle = i * angleIncrement;
                Vector3 spawnPosition = transform.position + Quaternion.Euler(0f, 180f, angle) * Vector3.up * radius;
                spawnPositions[i] = spawnPosition;
                GameObject polygonBullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
                polygonBullet.GetComponent<EnemyBullet>().dir = (player.transform.position - transform.position).normalized;
            }
            Debug.Log(1);
            currentTime = 0;
        }
    }
    private void Update()
    {
        SpawnBullet();
    }
}
