using UnityEngine;

public class GameManager : Singleton<GameManager>
{   
    public string chosenCar;

    public int milliseconds;
    public int seconds;
    public int minutes;    

    public int fastestLapMilliseconds = 99;
    public int fastestLapSeconds = 59;
    public int fastestLapMinutes = 59;

    public bool beginRace;
    // Start is called before the first frame update
   public void BeginRace()
    {
        beginRace = true;
    }

    public void EndRace()
    {
        beginRace = false;
    }
       
}
