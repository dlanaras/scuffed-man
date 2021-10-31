using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMoves : MonoBehaviour
{
    public float speed = 5;

    float randDir;

    private float timer = 0f;

    public float RandomGenerationDelayInSec = 0.5f;

    void Start()
    {
        randDir = Random.Range(-5f, 5f);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(randDir >= 2.5f) {
            transform.Translate(Vector2.down * Time.deltaTime * speed);
        } else if(randDir <= 2.5 && randDir >= 0) {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        } else if(randDir >= -2.5 && randDir <= 0) {
            transform.Translate(Vector2.up * Time.deltaTime * speed);
        } else if(randDir <= -2.5) {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        
        if(timer > RandomGenerationDelayInSec)
        {
            timer -= RandomGenerationDelayInSec;
            this.randDir = Random.Range(-5f, 5f);
        }
    }
}
