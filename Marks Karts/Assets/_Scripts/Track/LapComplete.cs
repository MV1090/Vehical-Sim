using UnityEngine;

public class LapComplete : MonoBehaviour
{
    [SerializeField] GameObject lapCompleteTrigger;
    [SerializeField] GameObject halfWayTrigger;

    int lapCounter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("has been triggered");            
            halfWayTrigger.SetActive(true);
            lapCompleteTrigger.SetActive(false);

            Timer.Instance.setLapTime(lapCounter);

            lapCounter++;

            if (lapCounter == 3)
                Time.timeScale = 0;

            Debug.Log(lapCounter.ToString());
        }
    }
}
