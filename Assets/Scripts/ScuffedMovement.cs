using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScuffedMovement : MonoBehaviour
{
    public float speed = 10f;
    void Update()
    {
        if(Input.GetKey("up")) {
            transform.Translate(Vector2.up * Time.deltaTime * speed);
        } else if(Input.GetKey("down")) {
            transform.Translate(Vector2.down * Time.deltaTime * speed);
        } else if(Input.GetKey("left")) {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        } else if(Input.GetKey("right")) {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
    }
}
