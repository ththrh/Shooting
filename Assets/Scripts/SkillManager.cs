using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillManager : MonoBehaviour
{
    public GameObject skillItem;
    public float createTime;
    [Range(0, 10)]
    public float minCreateTime;
    [Range(0, 10)]
    public float maxCreateTime;
    float currentTime;

    public int poolSize = 10;
    GameObject[] itemObjectPool;
    // Start is called before the first frame update
    void Start()
    {
        itemObjectPool = new GameObject[poolSize];
        for(int i = 0; i < itemObjectPool.Length; i++)
        {
            itemObjectPool[i] = Instantiate(skillItem);
            itemObjectPool[i].transform.position = transform.position;
            itemObjectPool[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int randValueX;
        int randValueY;
        currentTime += Time.deltaTime;
        if(currentTime > createTime)
        {
            randValueX = UnityEngine.Random.Range(-2, 3);
            randValueY = UnityEngine.Random.Range(0, 4); 
            for (int i = 0; i < poolSize; i++)
            {
                GameObject newItem = itemObjectPool[i];
                if (newItem.activeSelf == false)
                {
                    newItem.SetActive(true);
                    newItem.transform.position = new Vector3(randValueX, randValueY, 0);
                    break;
                }
            }

            createTime = UnityEngine.Random.Range(minCreateTime, maxCreateTime);
            currentTime = 0;
        }
    }
}
