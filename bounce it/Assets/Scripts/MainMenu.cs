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
    public bool CanClick;

    private void Start()
    {
        CanClick = true;
        _LevelSelectionButton._doClick = OpenLevelSelection;
        _BackButton._doClick = BackToMainMenu;
        _StartButton._doClick = StartTheGame;
    }

    public void SetLevel(int index)
    {
        _Canvases.ForEach((_canvas) =>
        {
            _canvas.DOFade(0, _Speed);
        });
        StartCoroutine(Delay(_Speed, index));
    }

    public void OpenLevelSelection()
    {
        _LevelSelection.DOMove(From.position, _Speed).SetEase(Ease.OutBounce);
        _MainMenu.DOMove(To.position, _Speed).SetEase(Ease.OutBounce);
    }
    public void StartTheGame()
    {
        _Canvases.ForEach((_canvas) => 
        {
            _canvas.DOFade(0, _Speed);
        });
        StartCoroutine(Delay(_Speed, 1));
    }
    public void BackToMainMenu()
    {
        if (!CanClick) return;
        _LevelSelection.DOMove(To.position, _Speed).SetEase(Ease.OutBounce);
        _MainMenu.DOMove(From.position, _Speed).SetEase(Ease.OutBounce);
    }

    IEnumerator Delay(float _Speed, int index)
    {
        yield return new WaitForSeconds(_Speed);
        SceneManager.LoadScene(index);
    }
}
