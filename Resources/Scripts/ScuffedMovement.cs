using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ScuffedMovement : MonoBehaviour
{
    public float speed = 10f;
    public float tailSpeed = 1f;
    /*public GameObject tail;
    private float spaceBetweenTails = 1f;*/
    void Update()
    {

                
            

            Transform[] allChildren = GetComponentsInChildren<Transform>();
            if(Input.GetKey("up")) {
                //transform.Translate(Vector2.up * Time.deltaTime * speed);
                //tail.transform.Translate(Vector2.up * Time.deltaTime * tailSpeed);
                //new Vector3(this.transform.position.x, this.transform.position.y + spaceBetweenTails, this.transform.position.z);

                                this.transform.Translate(Vector2.up * Time.deltaTime * speed);

                
            } else if(Input.GetKey("down")) {
                //transform.Translate(Vector2.down * Time.deltaTime * speed);
                    

                                this.transform.Translate(Vector2.down * Time.deltaTime * speed);

                
                //new Vector3(this.transform.position.x, this.transform.position.y + spaceBetweenTails, this.transform.position.z);
                //tail.transform.Translate(Vector2.down * Time.deltaTime * tailSpeed);
            } else if(Input.GetKey("left")) {
               // transform.Translate(Vector2.left * Time.deltaTime * speed);

                                this.transform.Translate(Vector2.left * Time.deltaTime * speed);
                
                //new Vector3(this.transform.position.x + spaceBetweenTails, this.transform.position.y, this.transform.position.z);
                //tail.transform.Translate(Vector2.left * Time.deltaTime * tailSpeed);
            } else if(Input.GetKey("right")) {
                //transform.Translate(Vector2.right * Time.deltaTime * speed);

                
                                this.transform.Translate(Vector2.right * Time.deltaTime * speed);

                                //this.transform.Translate(Vector2.right * Time.deltaTime * speed);
                                //Debug.Log("Childs Position: " + child.transform.position + " Parents position: " + this.transform.position);
                                //this.transform.Translate(Vector2.right * speed * Time.deltaTime);
                //new Vector3(this.transform.position.x + spaceBetweenTails, this.transform.position.y, this.transform.position.z);
                //tail.transform.Translate(Vector2.right * Time.deltaTime * tailSpeed);
                //BAD IDEA: TAIL MOVEMENT SCRIPT WITH REFERENCE TO Player -> Every tail has it
                //TODO: is position of tail == scuffed man -> move them to opposite direction and then add the normal movement script -> with foreach get all children
            }
    
}
}
