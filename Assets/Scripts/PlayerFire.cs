using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ ����� �Է�(space)�� �޾� �Ѿ��� �����Ѵ�.
public class PlayerFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunpos;
    public int maxSkillLevel = 3;
    int skillLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            ExcuteSkill(skillLevel);
        }
    }

    private void ExcuteSkill(int _skillLevel)
    {
        switch(_skillLevel)
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
            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.position = gunpos.transform.position;
        }
        void ExecuteSkill1()
        {
            GameObject newBullet = Instantiate(bullet);
            GameObject newBullet2 = Instantiate(bullet);

            newBullet.transform.position = gunpos.transform.position + new Vector3(-0.3f, 0 ,0);
            newBullet2.transform.position = gunpos.transform.position + new Vector3(0.3f, 0, 0);
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
            for(int i = 0; i< 24; i++)
            {
                newBullets[i] = Instantiate(bullet);
                newBullets[i].transform.position = gunpos.transform.position + new Vector3(0, -1, 0);
                newBullets[i].transform.rotation = Quaternion.Euler(0,0,15 * (i+1));
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
            if(skillLevel > maxSkillLevel)
            {
                skillLevel = maxSkillLevel;
            }
            Destroy(other.gameObject);
        }
    }

    private void OnValidate()
    {
        
    }
}
