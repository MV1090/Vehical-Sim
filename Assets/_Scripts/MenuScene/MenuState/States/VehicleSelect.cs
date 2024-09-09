using UnityEngine;


public class VehicleSelect : BaseMenu
{
    [SerializeField] CarSpawnManager spawnManager;
    public override void InitState(MenuController ctx)
    {
        base.InitState(ctx);
        state = MenuController.MenuStates.VehicleSelector;
    }

    public override void EnterState()
    {
        base.EnterState();
        Time.timeScale = 1.0f;
        
    }

    public override void ExitState()
    {
        base.ExitState();
        Time.timeScale = 0.0f;
    }

    public void JumpToGameState()
    {
        context.SetActiveState(MenuController.MenuStates.GameState);
        
    }
    public void JumpToMainMenu()
    {
        context.SetActiveState(MenuController.MenuStates.MainMenu);
    }
}
