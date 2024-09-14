using UnityEngine;

public class LapComplete : MonoBehaviour
{
    [SerializeField] GameObject lapCompleteTrigger;
    [SerializeField] GameObject halfWayTrigger;

    [SerializeField] GameState gameState;
    [SerializeField] int numberOfLaps;

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

            if (lapCounter == numberOfLaps)
            {
                Time.timeScale = 0;
                lapCounter = 0;
                GameManager.Instance.EndRace();
                gameState.JumpToGameOver();
            }              
                       
        }
    }
  
}
