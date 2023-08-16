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

    Camera mainCamera;

    public GameObject Item;
    public GameObject explosionEffect;


    private void Awake()
    {

    }
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
        if(player != null)
        {
            if (player.activeSelf == false)
            {
                gameObject.SetActive(false);
            }
        }
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

            GameManager.Instance.DestroyScore += 100;

            if (randValue < 8)
            {
                GameObject newItem = Instantiate(Item);
                newItem.transform.position = transform.position;
            }
            GameObject newExplosion = Instantiate(explosionEffect);
            newExplosion.transform.position = transform.position;
            Destroy(newExplosion, 0.7f);
            gameObject.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        // 뷰포트 밖으로 나간 경우 오브젝트 파괴
        if (viewPos.x < -1f || viewPos.x > 2f ||
            viewPos.y < -1f)
        {
            gameObject.SetActive(false);
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
            GameManager.Instance.AttackScore += 30;
            hp -= 10;
        }
    }
}
