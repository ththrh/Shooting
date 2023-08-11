using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    public float moveSpeed;
    public GameObject itemEffect;

    Camera mainCamera;
    float dir;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        transform.rotation = Quaternion.Euler(0, 0, 120);
        if(Random.Range(0,2) == 1)
        {
            dir = 1;
        }
        else
        {
            dir = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * moveSpeed * Time.deltaTime); 
        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        if (viewPos.x <= 0 || viewPos.x >= 1)
        {
            dir *= -1;  
            transform.rotation = Quaternion.Euler(0, 0, -120 * dir);
        }
        if(viewPos.y < 0  || viewPos.y > 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject itemEff = Instantiate(itemEffect);
            itemEff.transform.position = transform.position;
            Destroy(itemEff, 0.7f);
        }
    }
    private void OnDestroy()
    {
        if(itemEffect != null)
        {
            GameObject soundManager = GameObject.Find("SoundManager");
            
            AudioSource audioSource = soundManager.GetComponent<SoundManager>().effAS;
            audioSource.clip = soundManager.GetComponent<SoundManager>().itemAudioClips[0];
            audioSource.Play();
        }
    }


}
