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
    // Start is called before the first frame update
    void Start()
    {
        
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
            GameObject newSkillItem = Instantiate(skillItem);
            newSkillItem.transform.position = new Vector3(randValueX, randValueY, 0);

            createTime = UnityEngine.Random.Range(minCreateTime, maxCreateTime);
            currentTime = 0;
        }
    }
}
