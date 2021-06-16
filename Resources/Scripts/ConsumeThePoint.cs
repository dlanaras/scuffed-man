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
    public float speed = 10f;
    public TMP_Text score; // link to text that display
    public GameObject player;
    public float space = 5f;
    private int i = 0; // score amount
    public int pointAmount; // Amount of points to get added when consuming a point
    private int totalPointObjects = 100; // for now defined like this later on probably with a loop
    private int tailCounter = 0;
    public float distance = 5f;
    private string direction = "right";
    private GameObject currentTail;
    //public float spaceBetweenTails = 1.5f;
    public List<Vector3> positionArray = new List<Vector3>();
    // Init for different colors to be used as Text color
    Color tenToForty = new Color(0, 255, 0, 255);
    Color fortyToSeventy = new Color(0, 123, 123, 255);
    Color seventyToNinety = new Color(0,0,255,255);
    Color ninetyNine = new Color(255,0,0,255);

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.CompareTag("Point")) {
            tailCounter++; 
            Destroy(other.gameObject); // Destroy the Point
            GameObject tail = new GameObject("Tail" + (Convert.ToString(tailCounter))); // create a new Tail Gameobject
            //tail.transform.position = tail.transform.position * Vector2.right * Input.GetAxis("Horizontal") * Time.deltaTime;

            // Add needed tail components like collider and scriptsa
            tail.AddComponent<BoxCollider2D>();
            BoxCollider2D tailCollider = tail.GetComponent<BoxCollider2D>();
            tailCollider.isTrigger = true;

            //tail.AddComponent<Rigidbody2D>();


            tail.AddComponent<SpriteRenderer>();
            Sprite tailSprite = Resources.Load<Sprite>("Textures/Enemy");
            SpriteRenderer tailSpriteR = tail.GetComponent<SpriteRenderer>();
            tailSpriteR.sprite = tailSprite;

            tail.AddComponent<OnTouchedByEnemy>();
            tail.tag = "Tail";

            //tail.transform.Translate(Vector2.left * Time.deltaTime * distance);

            /*tail.AddComponent<TailMovement>();
            TailMovement tailmover = tail.GetComponent<TailMovement>();
            if(tailCounter == 1) {
                tailmover.followObj = player;
            }else {
                tailmover.followObj = GameObject.Find("Tail" + Convert.ToString(tailCounter-1));
            }*/
            if(tailCounter == 1) {
                switch (direction)
                {
                    //spawn tail on opposite direction
                    case "up":
                        tail.transform.position = this.transform.position;
                        tail.transform.Translate(Vector2.down * Time.deltaTime * space);
                    break;
                    case "down":
                        tail.transform.position = this.transform.position;
                        tail.transform.Translate(Vector2.up * Time.deltaTime * space);
                    break;
                    case "left":
                        tail.transform.position = this.transform.position;
                        tail.transform.Translate(Vector2.right * Time.deltaTime * space);
                    break;
                    case "right":
                        tail.transform.position = this.transform.position;
                        tail.transform.Translate(Vector2.left * Time.deltaTime * space);
                    break;
                } 
                } else {
                    switch (direction) {
                        case "up":
                            tail.transform.position = this.transform.position;
                            tail.transform.Translate(Vector2.down * Time.deltaTime * space * tailCounter);
                        break;
                        case "down":
                            tail.transform.position = this.transform.position;
                            tail.transform.Translate(Vector2.up * Time.deltaTime * space * tailCounter);
                        break;
                        case "left":
                            tail.transform.position = this.transform.position;
                            tail.transform.Translate(Vector2.right * Time.deltaTime * space * tailCounter);
                        break;
                        case "right":
                            tail.transform.position = this.transform.position;
                            tail.transform.Translate(Vector2.left * Time.deltaTime * space * tailCounter);
                        break;
                    } 
                }

            currentTail = tail;


            // Assing Parent to new Object
            
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

    //TODO: if direction changes move tails to opposite direction of scuffed man

    private void Update() {
            if(Input.GetKey("up")) {
                this.transform.Translate(Vector2.up * Time.deltaTime * speed);
                int i = tailCounter;
                foreach (GameObject tail in GameObject.FindGameObjectsWithTag("Tail"))
                {
                    if(this.direction == "right") {
                        //Going from right to upwards 
                        tail.transform.position = this.transform.position;
                        tail.transform.Translate(Vector2.down * Time.deltaTime * space * i);
                        //tail.transform.position(Vector2.up * Time.deltaTime * speed);
                    } else if(this.direction == "left") {
                        tail.transform.position = this.transform.position;
                        tail.transform.Translate(Vector2.down * Time.deltaTime * space * i);
                    } else if(this.direction == "down") {
                        tail.transform.position = this.transform.position;
                        tail.transform.Translate(Vector2.down * Time.deltaTime * space * i);
                    }
                    i--;
                    tail.transform.Translate(Vector2.up * Time.deltaTime * speed);
                }
                this.direction = "up";



            } else if(Input.GetKey("down")) {
                this.transform.Translate(Vector2.down * Time.deltaTime * speed);
                int i = tailCounter;
                foreach (GameObject tail in GameObject.FindGameObjectsWithTag("Tail"))
                {
                    if(this.direction == "right") {
                        //Going from right to upwards 
                        tail.transform.position = this.transform.position;
                        tail.transform.Translate(Vector2.up * Time.deltaTime * space * i);
                        //tail.transform.position(Vector2.up * Time.deltaTime * speed);
                    } else if(this.direction == "left") {
                        tail.transform.position = this.transform.position;
                        tail.transform.Translate(Vector2.up * Time.deltaTime * space * i);
                    } else if(this.direction == "up") {
                        tail.transform.position = this.transform.position;
                        tail.transform.Translate(Vector2.up * Time.deltaTime * space * i);
                    }
                    i--;
                    tail.transform.Translate(Vector2.down * Time.deltaTime * speed);
                }
                this.direction = "down";



            } else if(Input.GetKey("left")) {
                this.transform.Translate(Vector2.left * Time.deltaTime * speed);
                int i = tailCounter;
                foreach (GameObject tail in GameObject.FindGameObjectsWithTag("Tail"))
                {
                    if(this.direction == "right") {
                        //Going from right to upwards 
                        tail.transform.position = this.transform.position;
                        tail.transform.Translate(Vector2.right * Time.deltaTime * space * i);
                        //tail.transform.position(Vector2.up * Time.deltaTime * speed);
                    } else if(this.direction == "up") {
                        tail.transform.position = this.transform.position;
                        tail.transform.Translate(Vector2.right * Time.deltaTime * space * i);
                    } else if(this.direction == "down") {
                        tail.transform.position = this.transform.position;
                        tail.transform.Translate(Vector2.right * Time.deltaTime * space * i);
                    }
                    i--;
                    tail.transform.Translate(Vector2.left * Time.deltaTime * speed);
                }
                this.direction = "left";



            } else if(Input.GetKey("right")) {
                this.transform.Translate(Vector2.right * Time.deltaTime * speed);
                int i = tailCounter;
                foreach (GameObject tail in GameObject.FindGameObjectsWithTag("Tail"))
                {
                    if(this.direction == "left") {
                        //Going from right to upwards 
                        tail.transform.position = this.transform.position;
                        tail.transform.Translate(Vector2.left * Time.deltaTime * space * i);
                        //tail.transform.position(Vector2.up * Time.deltaTime * speed);
                    } else if(this.direction == "up") {
                        tail.transform.position = this.transform.position;
                        tail.transform.Translate(Vector2.left * Time.deltaTime * space * i);
                    } else if(this.direction == "down") {
                        tail.transform.position = this.transform.position;
                        tail.transform.Translate(Vector2.left * Time.deltaTime * space * i);
                    }
                    i--;
                    tail.transform.Translate(Vector2.right * Time.deltaTime * speed);
                }
                this.direction = "right";
            }
    }

}

