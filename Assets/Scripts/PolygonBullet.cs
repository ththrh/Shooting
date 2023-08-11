using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PolygonBullet : MonoBehaviour
{
    public float speed;
    Vector3 dir;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        dir = (player.transform.position - transform.position).normalized;
        transform.Translate(dir * speed * Time.deltaTime);
    }
}
