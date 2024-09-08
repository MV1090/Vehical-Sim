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
    }
}
