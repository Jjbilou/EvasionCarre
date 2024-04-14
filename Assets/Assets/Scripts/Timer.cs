using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool active;

    TMP_Text text;
    float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            time += Time.deltaTime;
            string display = (time / 60 < 10 ? '0' + Math.Floor(time / 60).ToString() : Math.Floor(time / 60).ToString()) + ':' + (time % 60 < 10 ? '0' + Math.Floor(time % 60).ToString() : Math.Floor(time % 60).ToString());
            text.SetText(display);
        }
        else
        {
            if (PlayerPrefs.GetFloat("bestTime") < time)
            {
                PlayerPrefs.SetFloat("bestTime", time);
            }
        }
    }
}
