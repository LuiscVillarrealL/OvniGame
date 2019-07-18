using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    public float startTime = 10f;
    public float currentTime = 0f;

    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        /*float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timer.text = minutes + ":" + seconds;*/

        currentTime -= 1 * Time.deltaTime;

        string minutes = ((int)currentTime / 60).ToString();
        string seconds = (currentTime % 60).ToString("f2");

        timer.text = minutes + ":" + seconds; ;
    }
}
