using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 1.0f;
    public float scaleFactor = 1.0f;
    public float dir = 1.0f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        float x = transform.position.x;
        float y = Mathf.Sin(x/2-0.8f);
        //float y2 = transform.position.y;
        //float x2 = Mathf.Asin(y);

        transform.position = new Vector3(x, y, 0);
        transform.position += Vector3.right * Time.deltaTime * speed * dir;
        //이니셜 포지션과 더해보기

        //transform.position = new Vector3(x, y, 0);
        //transform.position += Vector3.down * Time.deltaTime * speed * dir;
    }
}
