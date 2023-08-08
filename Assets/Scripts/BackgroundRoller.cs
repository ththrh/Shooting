using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����� Material�� offset�� Y�� �����ӵ��� ��ȭ��Ų��. 
public class BackgroundRoller : MonoBehaviour
{
    public float speed;
    float currentTime;
    public Material backgroundMat;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += speed * Time.deltaTime;
        backgroundMat.SetTextureOffset("_MainTex", new Vector2(0, currentTime));
    }
}
