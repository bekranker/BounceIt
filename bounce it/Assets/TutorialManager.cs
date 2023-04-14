using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


public class TutorialManager : MonoBehaviour
{
    public ButtonEffect FuncionCaller;
    public TMP_Text _Text;
    public List<string> texted = new List<string>();
    public Goal _Goal;
    private int _index = 0;
    private bool a;

    void Start()
    {
        a = true;
        FuncionCaller._doClick += Do;
    }

    private void Update()
    {
        if (_Goal.DidWin && a)
        {
            GetComponent<CanvasGroup>().DOFade(0, .15f).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
            a = false;
        }
           
    }

    public void Do()
    {
        _index = (_index + 1 < texted.Count) ? _index + 1 : 0;

        _Text.text = texted[_index];

    }
}
