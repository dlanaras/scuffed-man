using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

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
    [SerializeField] public GameObject pointArray;
    private int totalPointObjects; // for now defined like this later on probably with a loop
    private int tailCounter = 0;
    public float distance = 5f;
    private string direction = "right";
    private GameObject currentTail;
    //public float spaceBetweenTails = 1.5f;
    public List<Vector3> positionArray = new List<Vector3>();
    // Init for different colors to be used as Text color
    Color tenToForty = new Color(0, 255, 0, 255);
    Color fortyToSeventy = new Color(0, 123, 123, 255);
    Color seventyToNinety = new Color(0, 0, 255, 255);
    Color ninetyNine = new Color(255, 0, 0, 255);


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Point"))
        {
            tailCounter++;
            Destroy(other.gameObject.transform.parent.gameObject); // Destroy the Point
            GameObject tail = new GameObject("Tail" + (Convert.ToString(tailCounter))); // create a new Tail Gameobject
            //tail.transform.position = tail.transform.position * Vector2.right * Input.GetAxis("Horizontal") * Time.deltaTime;

            // Add needed tail components like collider and scriptsa
            tail.AddComponent<BoxCollider2D>();
            BoxCollider2D tailCollider = tail.GetComponent<BoxCollider2D>();
            tailCollider.isTrigger = true;

            //tail.AddComponent<Rigidbody2D>();


            tail.AddComponent<SpriteRenderer>();
            Sprite tailSprite = Resources.Load<Sprite>("Textures/ScuffedMan_128_Tail");
            SpriteRenderer tailSpriteR = tail.GetComponent<SpriteRenderer>();
            tailSpriteR.sprite = tailSprite;

            tail.AddComponent<OnTouchedByEnemy>();
            tail.tag = "Tail";

            // HAS TAIL
            if (tailCounter >= 1)
            {
                switch (direction)
                {
                    case "up":
                        tail.transform.position.Set(this.transform.position[0], this.transform.position[1] - (space + tailCounter), 0);
                        break;
                    case "down":
                        tail.transform.position.Set(this.transform.position[0], this.transform.position[1] + (space + tailCounter), 0);
                        break;
                    case "left":
                        tail.transform.position.Set(this.transform.position[0] + (space + tailCounter), this.transform.position[1], 0);
                        break;
                    case "right":
                        tail.transform.position.Set(this.transform.position[0] - (space + tailCounter), this.transform.position[1], 0);
                        break;
                }
            }


            // POINTS
            i += pointAmount;
            score.text = "Score: " + i.ToString();
            totalPointObjects = pointArray.transform.childCount;

            if (i > (totalPointObjects * pointAmount) * 0.10 && i < (totalPointObjects * pointAmount) * 0.40)
            {
                score.color = tenToForty;
            }
            else if (i > (totalPointObjects * pointAmount) * 0.40 && i < (totalPointObjects * pointAmount) * 0.70)
            {
                score.color = fortyToSeventy;
            }
            else if (i > (totalPointObjects * pointAmount) * 0.70 && i < (totalPointObjects * pointAmount) * 0.99)
            {
                score.color = seventyToNinety;
            }
            else if (i >= (totalPointObjects * pointAmount) * 0.99)
            {
                score.color = ninetyNine;
            }
        }
    }

    private void MakeTailsFollowHead(Vector2 direction)
    {
        if (tailCounter > 0)
        {
            int i = tailCounter;
            Vector3 previousTailPos = new Vector3();
            foreach (GameObject tail in GameObject.FindGameObjectsWithTag("Tail"))
            {
                if (i == tailCounter)
                {
                    previousTailPos = tail.transform.position; //save tail pos
                    tail.transform.position = this.transform.position; //tail gets moved to position of head
                    this.transform.Translate(direction * Time.deltaTime * speed); //head moves

                }
                else
                {
                    Vector3 tempPos = tail.transform.position; //save tail pos
                    tail.transform.position = previousTailPos; //move tail to last tail location
                    previousTailPos = tempPos; //set previouspos to actually previouspos (tempPos)
                }

                i--;
            }
        }
        else
        {
            this.transform.Translate(direction * Time.deltaTime * speed);
        }
    }
    private void Update()
    {
        //rotation
        transform.rotation = Quaternion.identity;
        if (Input.GetKey("up"))
        {
            this.MakeTailsFollowHead(Vector2.up);
        }
        else if (Input.GetKey("down"))
        {
            this.MakeTailsFollowHead(Vector2.down);
        }
        else if (Input.GetKey("left"))
        {
            this.MakeTailsFollowHead(Vector2.left);
        }
        else if (Input.GetKey("right"))
        {
            this.MakeTailsFollowHead(Vector2.right);
        }

        // No More Points
        PlayerPrefs.SetInt("Score", i);
        if (pointArray.transform.childCount == 0)
        {
            Debug.Log("YES");
            SceneManager.LoadScene("Won");
        }
    }

}

