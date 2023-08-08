using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 dir = Vector3.up;
    public GameObject bulletExplosion;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        //transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Player") && gameObject.CompareTag("EnemyBullet"))
        {
            GameObject newExplosion = Instantiate(bulletExplosion);
            newExplosion.transform.position = transform.position;
            collision.gameObject.GetComponent<PlayerMove>().hp -= 10;
            Destroy(gameObject);
        }
    }
}
