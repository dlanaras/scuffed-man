using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToGithub : MonoBehaviour
{
    public void openGithub(string url) {
        Application.OpenURL(url);
    }
}
