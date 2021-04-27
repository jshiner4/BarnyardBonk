using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffWelcomeScreen : MonoBehaviour
{
    public GameObject welcomePanel; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WelcomePanel());
    }

    IEnumerator WelcomePanel()
    {
        yield return new WaitForSeconds(2);
        welcomePanel.SetActive(false);
    }
}
