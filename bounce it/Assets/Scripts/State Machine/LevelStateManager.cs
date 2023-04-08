using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelStateManager : MonoBehaviour
{
    public LevelBaseState CurrentState;

    [Space(10)]
    public MarketState _MarketState_ = new MarketState();
    public EditState _EditState_ = new EditState();
    public PlayModeState _PlayModeState_ = new PlayModeState();
    public bool EditMode;



    private void Start()
    {
        CurrentState = _EditState_;
        CurrentState.OnStart(this);
    }


    public void PlayMode()
    {
        CurrentState.ClickPlayMode(this);
        SwitchState(_PlayModeState_);
    }

    public void SwitchState(LevelBaseState toState)
    {
        CurrentState = toState;
        CurrentState.OnStart(this);
    }
}
