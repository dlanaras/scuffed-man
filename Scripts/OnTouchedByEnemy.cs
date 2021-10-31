using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTouchedByEnemy : MonoBehaviour
{
    public bool canKillYou = true;

    private void OnTriggerEnter2D(Collider2D other) {
        if((other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Tail")) && canKillYou == true) {
            Debug.Log("TOUCH");
            SceneManager.LoadScene("Lost");
        }
    }
}
