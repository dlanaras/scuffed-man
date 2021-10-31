using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMoves : MonoBehaviour
{
    public float speed = 5;

    float randDir;

    private float timer = 0f;

    public float RandomGenerationDelayInSec = 0.5f;

    private Rigidbody2D rigidbody2D;

    void Start()
    {
        randDir = Random.Range (-5f, 5f);
        rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(randDir >= 2.5f) {
            rigidbody2D.AddForce(Vector2.down * Time.deltaTime * speed, ForceMode2D.Impulse);
        } else if(randDir <= 2.5 && randDir >= 0) {
            rigidbody2D.AddForce(Vector2.left * Time.deltaTime * speed, ForceMode2D.Impulse);
        } else if(randDir >= -2.5 && randDir <= 0) {
            rigidbody2D.AddForce(Vector2.up * Time.deltaTime * speed, ForceMode2D.Impulse);
        } else if(randDir <= -2.5) {
            rigidbody2D.AddForce(Vector2.right * Time.deltaTime * speed, ForceMode2D.Impulse);
        }
        
        if(timer > RandomGenerationDelayInSec)
        {
            timer -= RandomGenerationDelayInSec;
            this.randDir = Random.Range(-5f, 5f);
        }
    }
}
