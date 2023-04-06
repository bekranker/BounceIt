using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;





public class MainMenu : MonoBehaviour
{
    [SerializeField] private ButtonEffect _StartButton, _LevelSelectionButton, _BackButton;
    [SerializeField] private Transform _LevelSelection, _MainMenu, From, To;
    [SerializeField, Range(0.05f, 5f)] private float _Speed;



    private void Start()
    {
        _LevelSelectionButton._doClick = OpenLevelSelection;
        _BackButton._doClick = BackToMainMenu;
    }


    public void OpenLevelSelection()
    {
        _LevelSelection.DOMove(From.position, _Speed).SetEase(Ease.OutBounce);
        _MainMenu.DOMove(To.position, _Speed).SetEase(Ease.OutBounce);
    }
    public void StartTheGame()
    {

    }
    public void BackToMainMenu()
    {
        _LevelSelection.DOMove(To.position, _Speed).SetEase(Ease.OutBounce);
        _MainMenu.DOMove(From.position, _Speed).SetEase(Ease.OutBounce);
    }
}
