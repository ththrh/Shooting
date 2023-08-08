using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 적 생성
// 필요 속성: 특정시간, 현재시간, 적 GameObject
// 순서 1. 특정 시간이 흐른다.
// 순서 2. 현재시간이 특정시간이되면
// 순서 3. 적을 생성한다.
public class EnemyManager : MonoBehaviour
{
    float createTime = 2.0f;
    public float minTime;
    public float maxTime;
    public GameObject enemy;


    private float currentTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        createTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= createTime)
        {
            GameObject enemyObject = Instantiate(enemy);
            enemyObject.transform.position = transform.position;
            
            currentTime = 0;
        }
    }
}
