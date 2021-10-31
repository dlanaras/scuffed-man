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
    private float spaceBetweenTails = 0.1f;
    public int speed = 0;
    private int amountOfPointObjects;
    public int pointValue;
    public GameObject pointGameObjects;
    private Vector2 direction;
    private Vector2 previousPos;
    private List<GameObject> tails = new List<GameObject>();
    Color tenToForty = new Color(0, 255, 0, 255);
    Color fortyToSeventy = new Color(0, 123, 123, 255);
    Color seventyToNinety = new Color(0, 0, 255, 255);
    Color ninetyNine = new Color(255, 0, 0, 255);

    private void Awake()
    {
        this.amountOfPointObjects = pointGameObjects.transform.childCount;
    }


    private void Update()
    {
        if (Input.GetKey("up"))
        {
            this.transform.rotation = new Quaternion(90, -90, 0, 1);
            this.direction = Vector2.up;
            this.MakeTailsFollowHeadAndMove();

        }
        else if (Input.GetKey("down"))
        {
            this.transform.rotation = new Quaternion(90, 90, 0, 1);
            this.direction = Vector2.down;
            this.MakeTailsFollowHeadAndMove();

        }
        else if (Input.GetKey("left"))
        {
            this.transform.rotation = Quaternion.identity;
            this.direction = Vector2.left;
            this.MakeTailsFollowHeadAndMove();

        }
        else if (Input.GetKey("right"))
        {
            this.transform.rotation = new Quaternion(0, 90, 0, 1);

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
        if (tails.Count > 0)
        {
            previousPos = this.transform.position;


            previousPos = new Vector2(this.transform.position[0], this.transform.position[1]);
            GetComponent<Rigidbody2D>().AddForce(this.direction * Time.deltaTime * speed, ForceMode2D.Impulse);

            Vector2 tmp = Vector2.zero;

            for (int i = 0; i < tails.Count; i++)
            {
                tmp = tails[i].transform.position;
                tails[i].transform.position = previousPos;
                previousPos = tmp;
                previousPos = new Vector2(tmp[0], tmp[1]);
                this.RotateTailAccordingToDirection(tails[i]);
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(this.direction * Time.deltaTime * speed, ForceMode2D.Impulse);
        }

    }

    private void RotateTailAccordingToDirection(GameObject tail)
    {
        if (this.direction == Vector2.up)
        {
            tail.transform.rotation = new Quaternion(90, -90, 0, 1);
        }
        else if (this.direction == Vector2.down)
        {
            tail.transform.rotation = new Quaternion(90, 90, 0, 1);
        }
        else if (this.direction == Vector2.left)
        {
            tail.transform.rotation = Quaternion.identity;
        }
        else if (this.direction == Vector2.right)
        {
            tail.transform.rotation = new Quaternion(0, 90, 0, 1);
        }
    }


    private void CreateTail()
    {
        GameObject tail = new GameObject("Tail" + (Convert.ToString(tails.Count + 1)));
        tails.Add(tail);
        //place new tail on opposite direction of player with distance based of spaceBetweenTails and tailCounter
        tail.transform.position = this.transform.position;
        tail.transform.Translate((direction * -1 * spaceBetweenTails) * tails.Count);

        // Add needed tail components like collider and scripts
        tail.AddComponent<BoxCollider2D>();
        BoxCollider2D tailCollider = tail.GetComponent<BoxCollider2D>();
        tailCollider.isTrigger = true;

        tail.AddComponent<SpriteRenderer>();
        Sprite tailSprite = Resources.Load<Sprite>("Textures/ScuffedMan_128_Tail");
        SpriteRenderer tailSpriteR = tail.GetComponent<SpriteRenderer>();
        tailSpriteR.sprite = tailSprite;
        tailSpriteR.sortingOrder = tails.Count;

        tail.AddComponent<OnTouchedByEnemy>();
        tail.tag = "Tail";

    }

}
