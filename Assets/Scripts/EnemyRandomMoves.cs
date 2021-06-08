using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMoves : MonoBehaviour
{
    public float speed = 5;
    private int times = 0;
    float randDir = 5f;
    void Update()
    {
        times++;
        if(randDir >= 2.5f) {
            transform.Translate(Vector2.down * Time.deltaTime * speed);
        } else if(randDir <= 2.5 && randDir >= 0) {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        } else if(randDir >= -2.5 && randDir <= 0) {
            transform.Translate(Vector2.up * Time.deltaTime * speed);
        } else if(randDir <= -2.5) {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        if(times % 40 == 0) {
            randDir = Random.Range(-5f, 5f);
        }
    }
}
