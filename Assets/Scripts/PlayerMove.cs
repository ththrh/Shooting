using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float hp = 100;

    // 카메라, 스크린의 경계, 플레이어의 너비와 높이
    private Camera mainCamera;
    private Vector2 screenBounds;   
    private float playerWidth;
    private float playerHeight;

    GameManager gameManager;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        //플레이어 테두리의 x,y좌표의 경계
        playerWidth = GetComponent<MeshRenderer>().bounds.extents.x;
        playerHeight = GetComponent<MeshRenderer>().bounds.extents.y;

        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        
        Vector3 dir = Vector3.right * h + Vector3.up * v;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);

        if(hp <= 0)
        {
            gameManager.bestScore = gameManager.attackScore + gameManager.destroyScore;

            PlayerPrefs.SetInt("Best", gameManager.bestScore);
            Destroy(gameObject);
        }
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + playerWidth, screenBounds.x - playerWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + playerHeight, screenBounds.y - playerHeight);
        transform.position = viewPos;
    }
}
