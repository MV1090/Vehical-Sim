using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : Singleton<Timer>
{
    public UnityEvent<float> OnTimerValueChanged;

    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text[] lapTimeText;
   

    private int milliseconds;    
    private int seconds;
    private int minutes;
    private float currentTime;

    private float lapTime; 
    private int lapMilliseconds;
    private int lapSeconds;   
    private int lapMinutes;

    //public int fastestLapMilliseconds = 99;
    //public int fastestLapSeconds = 59;
    //public int fastestLapMinutes = 59;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        lapTime += Time.deltaTime;  
        UpdateTimer(currentTime);
        UpdateLapTimer(lapTime);

        timerText.text = "Time " + string.Format("{00:00}:{01:00}:{02:00}", minutes, seconds, milliseconds);
    }

    private void UpdateTimer(float time)
    {
        minutes = (int)Mathf.FloorToInt(time / 60);
        seconds = (int)Mathf.FloorToInt(time % 60);
        milliseconds = (int)(time * 100) % 100;
    }

    private void UpdateLapTimer(float time)
    {
        lapMinutes = (int)Mathf.FloorToInt(time / 60);
        lapSeconds = (int)Mathf.FloorToInt(time % 60);
        lapMilliseconds = (int)(time * 100) % 100;
    }

    public void ResetLapTimer() 
    {
        if (lapMinutes <= GameManager.Instance.fastestLapMinutes)
        {
            if (lapSeconds + (60 * lapMinutes) <= GameManager.Instance.fastestLapSeconds + (60 * GameManager.Instance.fastestLapMinutes) || lapSeconds == GameManager.Instance.fastestLapSeconds && lapMilliseconds < GameManager.Instance.fastestLapMilliseconds)      
            {
                GameManager.Instance.fastestLapMinutes = lapMinutes;
                GameManager.Instance.fastestLapSeconds = lapSeconds;
                GameManager.Instance.fastestLapMilliseconds = lapMilliseconds;                             
            }                  
        }

        lapTime = 0; 
    }

    public int GetSeconds() { return seconds; }

    public int GetMinutes() { return minutes; }

    public int GetMilliseconds() { return milliseconds; }

    public void setLapTime(int lap)
    {        
        lapTimeText[lap].text = "L" + (lap+1) + " " + string.Format("{00:00}:{01:00}:{02:00}", lapMinutes, lapSeconds, lapMilliseconds);
        ResetLapTimer();
    }

    public void ResetTimer()
    {
        ResetLapTimer();
        UpdateLapTimer(0);

        for (int i = 0; i < lapTimeText.Length; i++)
        {
            lapTimeText[i].text = "L" + (i + 1) + " " + string.Format("{00:00}:{01:00}:{02:00}", lapMinutes, lapSeconds, lapMilliseconds);
        }
        currentTime = 0;
        
    }

    private void OnDisable()
    {
        ResetTimer();
    }



}
