using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToCredits : MonoBehaviour
{
    public void loadCredits() {
        SceneManager.LoadScene("Credits");
    }
}
