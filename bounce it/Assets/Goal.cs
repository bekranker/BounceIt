using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Goal : MonoBehaviour
{
    [Space(10)]
    [SerializeField] private GameObject _WinPanel;
    [SerializeField] private LevelStateManager _LevelStateManager;
    [SerializeField] private List<GameObject> extras = new List<GameObject>();
    [SerializeField] CanvasGroup mainSettings;
    [SerializeField] TMP_Text _LevelNameShadow;
    [SerializeField] Image _WhiteBackground;
    [HideInInspector] public bool DidWin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            ActiveWinPanel();
            DidWin = true;
            CreateAudio.PlayAudio("kazan", .1f, "General", "Sound");
        }

    }

    private void ActiveWinPanel()
    {
        _WinPanel.SetActive(true);
        _WinPanel.GetComponent<CanvasGroup>().DOFade(1, _LevelStateManager.Speed);
        Toses();
        SaveLevel();
    }

    private void Toses()
    {
        mainSettings.DOFade(0, _LevelStateManager.Speed);
        _LevelNameShadow.DOFade(0, _LevelStateManager.Speed);
        _WhiteBackground.DOFade(1, _LevelStateManager.Speed);
        mainSettings.interactable = false;
        extras.ForEach((_image) => 
        {
            if (_image.gameObject.GetComponent<Image>() != null)
            {
                _image.gameObject.GetComponent<Image>().DOFade(0, _LevelStateManager.Speed);
            }
            if (_image.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                _image.gameObject.GetComponent<SpriteRenderer>().DOFade(0, _LevelStateManager.Speed);
            }
            if (_image.gameObject.GetComponent<TMP_Text>() != null)
            {
                _image.gameObject.GetComponent<TMP_Text>().DOFade(0, _LevelStateManager.Speed);
            }
            else
            {
                return;
            }
        });
        _LevelStateManager.ToGray.ForEach((_image) =>
        {
            if (_image.gameObject.GetComponent<Image>() != null)
            {
                _image.gameObject.GetComponent<Image>().DOFade(0, _LevelStateManager.Speed);
            }
            if (_image.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                _image.gameObject.GetComponent<SpriteRenderer>().DOFade(0, _LevelStateManager.Speed);
            }
            if (_image.gameObject.GetComponent<TMP_Text>() != null)
            {
                _image.gameObject.GetComponent<TMP_Text>().DOFade(0, _LevelStateManager.Speed);
            }
            else
            {
                return;
            }
        });
        _LevelStateManager.ToWhite.ForEach((_image) =>
        {
            if (_image.gameObject.GetComponent<Image>() != null)
            {
                _image.gameObject.GetComponent<Image>().DOFade(0, _LevelStateManager.Speed);
            }
            if (_image.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                _image.gameObject.GetComponent<SpriteRenderer>().DOFade(0, _LevelStateManager.Speed);
            }
            if (_image.gameObject.GetComponent<TMP_Text>() != null)
            {
                _image.gameObject.GetComponent<TMP_Text>().DOFade(0, _LevelStateManager.Speed);
            }
            else
            {
                return;
            }
        });
        _LevelStateManager.ToFadeZero.ForEach((_fadeObjedct) =>
        {
            if (_fadeObjedct.gameObject.GetComponent<Image>() != null)
            {
                _fadeObjedct.gameObject.GetComponent<Image>().DOFade(0, _LevelStateManager.Speed);
            }
            if (_fadeObjedct.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                _fadeObjedct.gameObject.GetComponent<SpriteRenderer>().DOFade(0, _LevelStateManager.Speed);
            }
            if (_fadeObjedct.gameObject.GetComponent<TMP_Text>() != null)
            {
                _fadeObjedct.gameObject.GetComponent<TMP_Text>().DOFade(0, _LevelStateManager.Speed);
            }
        });
        _LevelStateManager.ToFadeOne.ForEach((_fadeObjedct) =>
        {
            if (_fadeObjedct.gameObject.GetComponent<Image>() != null)
            {
                _fadeObjedct.gameObject.GetComponent<Image>().DOFade(0, _LevelStateManager.Speed);
            }
            if (_fadeObjedct.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                _fadeObjedct.gameObject.GetComponent<SpriteRenderer>().DOFade(0, _LevelStateManager.Speed);
            }
            if (_fadeObjedct.gameObject.GetComponent<TMP_Text>() != null)
            {
                _fadeObjedct.gameObject.GetComponent<TMP_Text>().DOFade(0, _LevelStateManager.Speed);
            }
        });
    }
    private void SaveLevel()
    {
        if (!PlayerPrefs.HasKey($"Level: {SceneManager.GetActiveScene().buildIndex} is Unlocked"))
        {
            PlayerPrefs.SetFloat($"Level: {SceneManager.GetActiveScene().buildIndex} is Unlocked", 1f);
        }
    }
}
