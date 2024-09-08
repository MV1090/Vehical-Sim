using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VehicleSelect : BaseMenu
{
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
