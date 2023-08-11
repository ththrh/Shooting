using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public float createTime = 2.0f; 
    float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(player != null)
        {
            if (currentTime > createTime)
            {
                GameObject newBullet = Instantiate(bullet);
                newBullet.transform.position = transform.position;
                newBullet.tag = "EnemyBullet";

                Vector3 newDir = (player.transform.position - transform.position).normalized;
                newBullet.GetComponent<EnemyBullet>().dir = newDir;

                currentTime = 0;
            }
        }
    }
}
