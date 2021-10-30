using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class ConsumeThePoint : MonoBehaviour
{

    public TMP_Text scoreTMP;
    private int scoreAmount = 0;
    public float spaceBetweenTails = 0.1f;
    public int speed = 0;
    private int amountOfPointObjects;
    public int pointValue;
    public GameObject pointGameObjects;
    private int tailCounter = 0;
    private Vector2 previousTailPos = new Vector2();
    private Vector2 direction;
    private List<GameObject> gameObjects = new List<GameObject>();
    Color tenToForty = new Color(0, 255, 0, 255);
    Color fortyToSeventy = new Color(0, 123, 123, 255);
    Color seventyToNinety = new Color(0, 0, 255, 255);
    Color ninetyNine = new Color(255, 0, 0, 255);

    private void Awake()
    {
        this.amountOfPointObjects = pointGameObjects.transform.childCount;
        gameObjects.Add(this.gameObject);
    }


    private void Update()
    {
        if (Input.GetKey("up"))
        {
            this.direction = Vector2.up;
            this.MakeTailsFollowHeadAndMove();
        }
        else if (Input.GetKey("down"))
        {
            this.direction = Vector2.down;
            this.MakeTailsFollowHeadAndMove();
        }
        else if (Input.GetKey("left"))
        {
            this.direction = Vector2.left;
            this.MakeTailsFollowHeadAndMove();
        }
        else if (Input.GetKey("right"))
        {
            this.direction = Vector2.right;
            this.MakeTailsFollowHeadAndMove();
        }

        if (pointGameObjects.transform.childCount == 0)
        {
            Debug.Log("YES");
            SceneManager.LoadScene("Won");
        }
    }


    private void OnTriggerEnter2D(Collider2D otherCollider2D)
    {

        if (otherCollider2D.gameObject.CompareTag("Point"))
        {
            Destroy(otherCollider2D.gameObject.transform.parent.gameObject); // Destroy consumed point
            this.CreateTail();

            // POINTS
            scoreAmount += pointValue;
            PlayerPrefs.SetInt("Score", scoreAmount);
            scoreTMP.text = "Score: " + scoreAmount.ToString();
            this.SetScoreColorAccordingToPercentage();
        }
    }

    private void SetScoreColorAccordingToPercentage()
    {
        int maxPointValue = amountOfPointObjects * pointValue;

        if (scoreAmount < maxPointValue * 0.4) //40% or less amount of max points collected
        {
            scoreTMP.color = tenToForty;
        }
        else if (scoreAmount > maxPointValue * 0.4 && scoreAmount < maxPointValue * 0.7) //between 40% and 70%
        {
            scoreTMP.color = fortyToSeventy;
        }
        else if (scoreAmount > maxPointValue * 0.7 && scoreAmount < maxPointValue * 0.90) //between 70% and 90%
        {
            scoreTMP.color = seventyToNinety;
        }
        else if (scoreAmount >= maxPointValue * 0.90) //more than 90%
        {
            scoreTMP.color = ninetyNine;
        }
    }

    private void MakeTailsFollowHeadAndMove()
    {
        //rotation
        //transform.rotation = Quaternion.identity;

        if (tailCounter > 0)
        {
            int i = tailCounter;

            this.transform.Translate(this.direction * Time.deltaTime * speed);


            if (i == tailCounter)
            {
                previousTailPos = gameObject.transform.position;
                gameObject.transform.Translate(direction * Time.deltaTime * speed);
            }
            else
            {
                Vector2 tempPos = gameObject.transform.position;
                gameObject.transform.position = previousTailPos;
                previousTailPos = tempPos;
            }



            /*
                            previousTailPos = tail.transform.position; //save tail pos
                            tail.transform.position.Set(direction[0] * Time.deltaTime * -1 * spaceBetweenTails, this.transform.position[1], 0); // = this.transform.position; //tail gets moved to position of head
                            this.transform.Translate(this.direction * Time.deltaTime * speed); //head moves
                            tail.transform.Translate(direction * -1 * spaceBetweenTails * Time.deltaTime);
                            //tail.transform.Translate((direction * -1 * spaceBetweenTails) * tailCounter);


                            Vector2 tempPos = tail.transform.position; //save tail pos
                            tail.transform.position = previousTailPos; //move tail to last tail location
                            previousTailPos = tempPos; //set previouspos to actually previouspos (tempPos)

            */
            i--;


        }
        else
        {
            this.transform.Translate(this.direction * Time.deltaTime * speed);
        }
    }

    private void CreateTail()
    {
        tailCounter++;

        GameObject tail = new GameObject("Tail" + (Convert.ToString(tailCounter)));
        //place new tail on opposite direction of player with distance based of spaceBetweenTails and tailCounter
        tail.transform.position = this.transform.position;
        tail.transform.Translate((direction * -1 * spaceBetweenTails) * tailCounter);

        // Add needed tail components like collider and scripts
        tail.AddComponent<BoxCollider2D>();
        BoxCollider2D tailCollider = tail.GetComponent<BoxCollider2D>();
        tailCollider.isTrigger = true;

        tail.AddComponent<SpriteRenderer>();
        Sprite tailSprite = Resources.Load<Sprite>("Textures/ScuffedMan_128_Tail");
        SpriteRenderer tailSpriteR = tail.GetComponent<SpriteRenderer>();
        tailSpriteR.sprite = tailSprite;
        tailSpriteR.sortingOrder = tailCounter;

        tail.AddComponent<OnTouchedByEnemy>();
        tail.tag = "Tail";

    }

}
