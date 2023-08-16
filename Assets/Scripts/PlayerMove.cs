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
    private Vector3 startPos;

    public VariableJoystick joystick;

    private void Awake()
    {
        startPos = transform.position;
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
#if UNITY_Android
        float h = joystick.Horizontal;
        float v = joystick.Vertical;
#elif UNITY_EDITOR || UNITY_STANDALONE
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
#endif

        Vector3 dir = Vector3.right * h + Vector3.up * v;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);

        if(hp <= 0)
        {
            GameManager.Instance.SetBestScore();
            PlayerPrefs.SetInt("Best", GameManager.Instance.bestScore);
            gameObject.SetActive(false);
        }
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + playerWidth, screenBounds.x - playerWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + playerHeight, screenBounds.y - playerHeight);
        transform.position = viewPos;
    }

    private void OnDisable()
    {
        GameManager.Instance.GameOver();
    }

    public void PlayerInitailize()
    {
        transform.position = startPos;
        hp = 100;
        gameObject.GetComponent<PlayerFire>().skillLevel = 0;
    }
}
