using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 dir = Vector3.down;
    public int hp = 30;
    float randValue;
    GameObject player;

    private Camera mainCamera;

    public GameObject Item;
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        randValue = Random.Range(0, 10f);
        player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            if (randValue < 3)
            {
                dir = (player.transform.position - transform.position).normalized;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(randValue < 1)
        {
            if(player != null)
            {
                dir = (player.transform.position - transform.position).normalized;
            }
        }
        transform.position += dir * speed * Time.deltaTime;
        if (hp <= 0)
        {
            int randValue = Random.Range(0, 100);
            Debug.Log(randValue);
            if(randValue < 5)
            {
                GameObject newItem = Instantiate(Item);
                newItem.transform.position = transform.position;
            }
            GameObject newExplosion = Instantiate(explosionEffect);
            newExplosion.transform.position = transform.position;
            Destroy(newExplosion, 0.7f);
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        // ����Ʈ ������ ���� ��� ������Ʈ �ı�
        if (viewPos.x < -0.2f || viewPos.x > 1.2f ||
            viewPos.y < -0.2f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hp = 0;
            collision.gameObject.GetComponent<PlayerMove>().hp -= 30;
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hp -= 10;
        }
    }
}