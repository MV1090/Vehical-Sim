using UnityEngine;

public class GameState : BaseMenu
{

    [SerializeField] Camera menuCam;   
    
    public override void InitState(MenuController ctx)
    {
        base.InitState(ctx);
        state = MenuController.MenuStates.GameState;
    }

    public override void EnterState()
    {
        base.EnterState();
        Time.timeScale = 1.0f;
        menuCam.enabled = false;      
        
    }

    public override void ExitState()
    {
        base.ExitState();
        Time.timeScale = 0.0f;
        CarSpawnManager.Instance.activeCar.gameObject.SetActive(false);
        GameManager.Instance.minutes = Timer.Instance.GetMinutes();
        GameManager.Instance.seconds = Timer.Instance.GetSeconds();
        GameManager.Instance.milliseconds = Timer.Instance.GetMilliseconds();


    }

    public void JumpToGameOver()
    {
        context.SetActiveState(MenuController.MenuStates.GameOver);
    }
}
