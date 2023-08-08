using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//배경의 Material의 offset의 Y를 일정속도로 변화시킨다. 
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
