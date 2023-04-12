using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class WinManager : MonoBehaviour
{
    [SerializeField] private ButtonEffect _HomeButton, _RestartButton, _NextLevelButton;
    [SerializeField] private CanvasGroup _CanvasGroup;
    [SerializeField] Image _WhiteBackground;

    void Start()
    {
        _HomeButton._doClick = ReturnHome;
        _RestartButton._doClick = RestartLevel;
        _NextLevelButton._doClick = NextLevel;
    }

    private void ReturnHome() => SceneManager.LoadScene(0);
    private void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    private void NextLevel()
    {
        _CanvasGroup.DOFade(0, 0.75f).OnComplete(()=> 
        {
            _WhiteBackground.DOFade(0, 0.75f).OnComplete(() => 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            });
            
        });
    }

}
