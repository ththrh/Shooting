using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ����
// �ʿ� �Ӽ�: Ư���ð�, ����ð�, �� GameObject
// ���� 1. Ư�� �ð��� �帥��.
// ���� 2. ����ð��� Ư���ð��̵Ǹ�
// ���� 3. ���� �����Ѵ�.
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
