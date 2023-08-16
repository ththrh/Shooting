using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int attackScore;
    public int bestScore;
    public int destroyScore;

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
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
