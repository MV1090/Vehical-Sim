using UnityEngine;


public class MainMenu : BaseMenu
{
    public override void InitState(MenuController ctx)
    {
        base.InitState(ctx);
        state = MenuController.MenuStates.MainMenu;
    }

    public override void EnterState()
    {
        base.EnterState();
        Time.timeScale = 0.0f;           
    }

    public override void ExitState()
    {
        base.ExitState();
        Time.timeScale = 1.0f;
    }

    public void JumpToVehicleSelector()
    {
       context.SetActiveState(MenuController.MenuStates.VehicleSelector);
    }

    public void JumpToGameState()
    {
        context.SetActiveState(MenuController.MenuStates.GameState);
    }
  
}
