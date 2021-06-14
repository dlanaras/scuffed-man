using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class ConsumeThePoint : MonoBehaviour
{
    /*  GameObject totalPointObjects = GameObject.FindWithTag("Point");
    private void Awake() {
        Debug.Log(totalPointObjects.name + " has " + totalPointObjects.transform.childCount + " children");
    }    */
    public TMP_Text score; // link to text that display
    private int i = 0; // score amount
    public int pointAmount; // Amount of points to get added when consuming a point
    private int totalPointObjects = 100; // for now defined like this later on probably with a loop
    //public float spaceBetweenTails = 1.5f;
    public List<Vector3> positionArray = new List<Vector3>();
    // Init for different colors to be used as Text color
    Color tenToForty = new Color(0, 255, 0, 255);
    Color fortyToSeventy = new Color(0, 123, 123, 255);
    Color seventyToNinety = new Color(0,0,255,255);
    Color ninetyNine = new Color(255,0,0,255);

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.CompareTag("Point")) {
            Destroy(other.gameObject); // Destroy the Point
            GameObject tail = new GameObject("Tail"); // create a new Tail Gameobject
            //tail.transform.position = tail.transform.position * Vector2.right * Input.GetAxis("Horizontal") * Time.deltaTime;

            // Add needed tail components like collider and scriptsa
            /* tail.AddComponent<BoxCollider2D>();
            BoxCollider2D tailCollider = tail.GetComponent<BoxCollider2D>();
            tailCollider.isTrigger = true;*/

            //tail.AddComponent<Rigidbody2D>();

            tail.AddComponent<SpriteRenderer>();
            Sprite tailSprite = Resources.Load<Sprite>("Textures/Enemy");
            Debug.Log(tailSprite);
            SpriteRenderer tailSpriteR = tail.GetComponent<SpriteRenderer>();
            tailSpriteR.sprite = tailSprite;

            tail.AddComponent<OnTouchedByEnemy>();
            // Assing Parent to new Object
            tail.transform.SetParent(this.transform);
            positionArray.Add(tail.transform.position);


            tail.transform.position = positionArray.First();
            
             // Tail gets created and then gets moved once in the opposite direction of the direction of scuffed man and then follows him at same speed
            //spaceBetweenTails += spaceBetweenTails;

            i += pointAmount;
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

