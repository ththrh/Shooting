using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 1.0f;
    public float scaleFactor = 1.0f;
    public float dir = 1.0f;

    public int moveType;

    [Header("Circle Move")]
    public float radius = 2f;

    private Vector3 center;
    private float angle;

    [Space(10f)]
    [Header("Sin Move")]
    public float amplitude;
    public float frequency;
    public float phase;

    private Vector3 initialPosition;

    private void Start()
    {
        center = new Vector3(0, transform.position.y, 0);
        initialPosition = transform.position;
    }

    private void Update()
    {
        angle += Time.deltaTime;
        switch (moveType)
        {
            case 0:
                SinMove();
                break;
            case 1:
                CircleMove(angle);
                break;
        }

    }

    public void SinMove()
    {
        float x = transform.position.x;
        float y = amplitude * Mathf.Sin(frequency * x / 2 + phase);

        transform.position = new Vector3(x, initialPosition.y + y, 0);
        transform.position += Vector3.right * Time.deltaTime * speed * dir;
    }
    public void CircleMove(float angle)
    {
        angle += speed * Time.deltaTime;
        transform.position = center + new Vector3(Mathf.Cos(angle), 0.5f * Mathf.Sin(angle), 0) * radius;
    }
}
