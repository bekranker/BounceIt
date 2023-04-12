using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;



public class MainMenu : MonoBehaviour
{
    [SerializeField] private ButtonEffect _StartButton, _LevelSelectionButton, _BackButton;
    [SerializeField] private Transform _LevelSelection, _MainMenu, From, To;
    [SerializeField, Range(0.05f, 5f)] private float _Speed;
    [SerializeField] private List<CanvasGroup> _Canvases;


    private void Start()
    {
        _LevelSelectionButton._doClick = OpenLevelSelection;
        _BackButton._doClick = BackToMainMenu;
        _StartButton._doClick = StartTheGame;
    }


    public void OpenLevelSelection()
    {
        _LevelSelection.DOMove(From.position, _Speed).SetEase(Ease.OutBounce);
        _MainMenu.DOMove(To.position, _Speed).SetEase(Ease.OutBounce);
    }
    public async void StartTheGame()
    {
        _Canvases.ForEach((_canvas) => 
        {
            _canvas.DOFade(0, _Speed);
        });
        await Task.Delay(1000);
        SceneManager.LoadScene(1);
    }
    public void BackToMainMenu()
    {
        _LevelSelection.DOMove(To.position, _Speed).SetEase(Ease.OutBounce);
        _MainMenu.DOMove(From.position, _Speed).SetEase(Ease.OutBounce);
    }
}
