using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표 사용자 입력(space)를 받아 총알을 생성한다.
public class PlayerFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunpos;
    public int maxSkillLevel = 3;
    public int skillLevel = 0;

    public int poolSize = 500;
    GameObject[] bulletObjectPool;

    public VariableJoystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        bulletObjectPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            bulletObjectPool[i] = Instantiate(bullet);
            bulletObjectPool[i].SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
#if UNiTY_EDITOR || UNITY_STANDALONE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExcuteSkill();
        }
#endif
    }
    public void ExcuteSkill()
    {
        switch (skillLevel)
        {
            case 0:
                ExecuteSkill0();
                break;
            case 1:
                ExecuteSkill1();
                break;
            case 2:
                ExecuteSkill2();
                break;
            case 3:
                StartCoroutine(ExecuteSkill3());
                break;
            default:
                break;
        }

        void ExecuteSkill0()
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject newBullet = bulletObjectPool[i];
                if (newBullet.activeSelf == false)
                {
                    newBullet.SetActive(true);
                    newBullet.transform.position = gunpos.transform.position;
                    break;
                }
            }
        }
        void ExecuteSkill1()
        {
            int cnt = 0; for (int i = 0; i < poolSize; i++)
            {
                GameObject newBullet = bulletObjectPool[i];
                if (newBullet.activeSelf == false)
                {
                    newBullet.SetActive(true);
                    if (cnt == 0)
                    {
                        newBullet.transform.position = gunpos.transform.position + new Vector3(-0.3f, 0, 0);
                        cnt++;
                    }
                    else if (cnt == 1)
                    {
                        newBullet.transform.position = gunpos.transform.position + new Vector3(0.3f, 0, 0);
                        cnt++;
                    }
                    if (cnt == 2)
                    {
                        break;
                    }
                }
            }

        }

        void ExecuteSkill2()
        {
            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.position = gunpos.transform.position;

            GameObject newBullet2 = Instantiate(bullet);
            GameObject newBullet3 = Instantiate(bullet);

            newBullet2.transform.position = gunpos.transform.position + new Vector3(-0.3f, 0, 0);
            newBullet2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 30));
            newBullet2.GetComponent<Bullet>().dir = transform.up;

            newBullet3.transform.position = gunpos.transform.position + new Vector3(0.3f, 0, 0);
            newBullet3.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -30));
            newBullet3.GetComponent<Bullet>().dir = transform.up;
        }

        IEnumerator ExecuteSkill3()
        {
            GameObject[] newBullets = new GameObject[24];
            for (int i = 0; i < 24; i++)
            {
                newBullets[i] = Instantiate(bullet);
                newBullets[i].transform.position = gunpos.transform.position + new Vector3(0, -1, 0);
                newBullets[i].transform.rotation = Quaternion.Euler(0, 0, 15 * (i + 1));
                newBullets[i].GetComponent<Bullet>().dir = transform.up;
                yield return new WaitForSeconds(0.035f);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            skillLevel++;
            if (skillLevel > maxSkillLevel)
            {
                skillLevel = maxSkillLevel;
            }
            other.gameObject.SetActive(false);
        }
    }

    private void OnValidate()
    {

    }
}
