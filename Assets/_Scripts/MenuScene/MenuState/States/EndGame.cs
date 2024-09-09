using UnityEngine;
using TMPro;

public class EndGame : BaseMenu
{
    [SerializeField] Camera menuCam;

    [Header("Text")]
    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text fastestLap;
    
    public override void InitState(MenuController ctx)
    {
        base.InitState(ctx);
        state = MenuController.MenuStates.GameOver;
    }

    public override void EnterState()
    {
        base.EnterState();
        Time.timeScale = 0.0f;
        menuCam.enabled = true;
        
        timeText.text = "Time: " + string.Format("{00:00}:{01:00}:{02:00}", GameManager.Instance.minutes, GameManager.Instance.seconds, GameManager.Instance.milliseconds);
        fastestLap.text = "Fastest Lap: " + string.Format("{00:00}:{01:00}:{02:00}", GameManager.Instance.fastestLapMinutes, GameManager.Instance.fastestLapSeconds, GameManager.Instance.fastestLapMilliseconds);
    }

    public override void ExitState()
    {
        base.ExitState();
        Time.timeScale = 1.0f;
        GameManager.Instance.fastestLapMinutes = 59;
        GameManager.Instance.fastestLapSeconds = 59;
        GameManager.Instance.fastestLapMilliseconds = 99;
    }
    public void JumpToGameState()
    {
        context.SetActiveState(MenuController.MenuStates.GameState);

    }
    public void JumpToMainMenu()
    {
        context.SetActiveState(MenuController.MenuStates.MainMenu);
    }
    public void JumpToVehicleSelector()
    {
        context.SetActiveState(MenuController.MenuStates.VehicleSelector);
    }
}
