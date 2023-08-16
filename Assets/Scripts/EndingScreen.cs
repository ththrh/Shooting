using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndingScreen : MonoBehaviour
{
    public TMP_Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = PlayerPrefs.GetInt("Best").ToString() + " points";
    }

}
