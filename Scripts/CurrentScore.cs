using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentScore : MonoBehaviour
{
    public TMP_Text scoreText;
    void Start()
    {
        scoreText.text = scoreText.text + " " + PlayerPrefs.GetInt("Score").ToString();
    }
}
