using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentScore : MonoBehaviour
{
    public TMP_Text scoreText;
    void Awake()
    {
        Debug.Log(PlayerPrefs.GetInt("Score").ToString());
        scoreText.text = scoreText.text.Replace(" 0", " " + PlayerPrefs.GetInt("Score").ToString());
    }
}
