
using UnityEngine;

public abstract class LevelBaseState
{
    public abstract void OnStart(LevelStateManager levelStateManager);
    public abstract void ClickPlayMode(LevelStateManager levelStateManager);
    public abstract void OnEdit(LevelStateManager levelStateManager);
}
