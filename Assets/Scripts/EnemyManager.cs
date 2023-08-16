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

    public int poolSize = 10;
    private GameObject[] enemyObjectPool;

    private float currentTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        enemyObjectPool = new GameObject[poolSize];
        for (int i = 0; i < enemyObjectPool.Length; i++)
        {
            enemyObjectPool[i] = Instantiate(enemy);
            enemyObjectPool[i].transform.position = transform.position;
            enemyObjectPool[i].SetActive(false);
        }

        createTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= createTime)
        {
            for (int i = 0; i < enemyObjectPool.Length; i++)
            {
                GameObject enemyObject = enemyObjectPool[i];
                if (enemyObject.activeSelf == false)
                {
                    enemyObject.gameObject.GetComponent<Enemy>().hp = 30;
                    enemyObject.transform.position = transform.position;
                    enemyObject.SetActive(true);
                    currentTime = 0;
                    break;
                }
            }
            
        }
    }
}
