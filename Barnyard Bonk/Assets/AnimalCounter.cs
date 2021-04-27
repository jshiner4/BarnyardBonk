using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimalCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public int counter;

    public GameObject finishGameScreen;

    private string count;

    void Start()
    {
        counter = 0;
        count = "0";
    }

    void Update()
    {
        if (counter == 10)
        {
            finishGameScreen.SetActive(true);
        }
    }

    public void UpdateUICounter()
    {
        count = counter.ToString();
        counterText.text = count;
    }
}
