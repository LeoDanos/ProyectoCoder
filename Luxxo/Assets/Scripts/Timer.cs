using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    float timeLeft;
    bool timerOn = false;

    public TextMeshProUGUI timerTxt;
    Player playerScript;
   
    void Start()
    {
        playerScript = FindObjectOfType<Player>();
        timerOn = true;
    }

    void Update()
    {
        timeLeft = playerScript.countdown - 0.01f;

        if(timerOn)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else
            {
                timeLeft = 0;
                timerOn = false;
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
