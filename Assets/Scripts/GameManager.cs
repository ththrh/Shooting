using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Experimental.Rendering;

public class GameManager : MonoBehaviour
{
    private int attackScore;
    public GameObject endingScreen;
    public GameObject player;
    public int AttackScore
    {
        get
        {
            return attackScore;
        }
        set
        {
            attackScore = value;
            attackScoreUI.text = attackScore.ToString();
        }
    }
    private int destroyScore;
    public int DestroyScore
    {
        get
        {
            return destroyScore;
        }
        set
        {
            destroyScore = value;
            destroyScoreUI.text = destroyScore.ToString();
        }
    }
    public int bestScore;

    public TMP_Text attackScoreUI;
    public TMP_Text destroyScoreUI;
    public TMP_Text bestScoreUI;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            else return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
        attackScoreUI.text = "0";
        destroyScoreUI.text = "0";
        bestScoreUI.text = PlayerPrefs.GetInt("Best").ToString();

        player = GameObject.FindWithTag("Player");
    }

    public void SetBestScore()
    {
        bestScore = attackScore + destroyScore;
        attackScore = 0;
        destroyScore = 0;
        PlayerPrefs.SetInt("Best", bestScore);
    }
    public void SetDestroyScore()
    {
        destroyScore += 100;
        destroyScoreUI.text = destroyScore.ToString();
    }
    public void SetAttackScore()
    {
        attackScore += 30;
        attackScoreUI.text = attackScore.ToString();
    }

    public void GameOver()
    {
        endingScreen.gameObject.SetActive(true);
    }
    public void Restart()
    {
        endingScreen.gameObject.SetActive(false);
        player.SetActive(true);
        attackScore = 0;
        destroyScore = 0;
        player.GetComponent<PlayerMove>().PlayerInitailize();
    }
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif  
    }
}
