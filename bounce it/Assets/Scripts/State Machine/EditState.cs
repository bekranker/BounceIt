using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditState : LevelBaseState
{
    public override void OnEdit(LevelStateManager levelStateManager)
    {
    }

    public override void OnStart(LevelStateManager levelStateManager)
    {
        levelStateManager.EditMode = true;
    }

    public override void ClickPlayMode(LevelStateManager levelStateManager)
    {
    }
}
