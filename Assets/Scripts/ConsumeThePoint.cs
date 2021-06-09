using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ConsumeThePoint : MonoBehaviour
{
    public TMP_Text score; // link to text that display
    private int i = 0; // score amount
    public int pointAmount; // Amount of points to get added when consuming a point
    private int totalPointObjects = 100; // for now defined like this later on probably with a loop
    Color tenToForty = new Color(0, 255, 0, 255);
    Color fortyToSeventy = new Color(0, 123, 123, 255);
    Color seventyToNinety = new Color(0,0,255,255);
    Color ninetyNine = new Color(255,0,0,255);

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Point")) {
            i += pointAmount;
            Destroy(other.gameObject);
            score.text = "Score: " + i.ToString();
            
            if(i > totalPointObjects * 0.10 && i < totalPointObjects * 0.40) {
                score.color = tenToForty;
            }else if(i > totalPointObjects * 0.40 && i < totalPointObjects * 0.70) {
                score.color = fortyToSeventy;
            }else if(i > totalPointObjects * 0.70 && i < totalPointObjects * 0.99) {
                score.color = seventyToNinety;
            }else if(i >= totalPointObjects * 0.99) {
                score.color = ninetyNine;
            }
        }
    }
}
