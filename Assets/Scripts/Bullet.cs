using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 dir = Vector3.up;
    public GameObject bulletExplosion;
    private GameObject player;


    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(DisableBullet());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        if (player.activeSelf == false)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !gameObject.CompareTag("EnemyBullet"))
        {
            GameObject soundManager = GameObject.Find("SoundManager");
            AudioSource audioSource = soundManager.GetComponent<SoundManager>().effAS;
            audioSource.clip = soundManager.GetComponent<SoundManager>().explosionAudioclips[1];
            audioSource.Play();
            gameObject.SetActive(false);
        }
        if(collision.gameObject.CompareTag("Player") && gameObject.CompareTag("EnemyBullet"))
        {
            GameObject newExplosion = Instantiate(bulletExplosion);
            newExplosion.transform.position = transform.position;
            collision.gameObject.GetComponent<PlayerMove>().hp -= 10;

            GameObject soundManager = GameObject.Find("SoundManager");
            AudioSource audioSource = soundManager.GetComponent<SoundManager>().effAS;
            audioSource.clip = soundManager.GetComponent<SoundManager>().explosionAudioclips[0];
            audioSource.Play();
            
            gameObject.SetActive(false);
        }
    }

    IEnumerator DisableBullet()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        Debug.Log(1);
        transform.position = new Vector3(124124, 345235, 12923);
    }
}
